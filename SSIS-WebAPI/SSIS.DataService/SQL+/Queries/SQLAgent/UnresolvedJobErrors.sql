--+SqlPlusRoutine
    --&SelectType=MultiRow
    --&Comment=Returns list of job where last instance was not successful, ordered by most recent.
    --&Author=Todd Zimmerman
--+SqlPlusRoutine

--+Parameters

    DECLARE

    --+Output
    @Count int

--+Parameters

SELECT sjh.instance_id InstanceId
  ,sjh.job_id JobId
  ,j.name JobName
  ,sjh.step_id StepSequenceId
  ,sjh.step_name StepName
  ,step.subsystem
  ,step.command
  ,sjh.message Message
  ,jt.start_time StartedAt
  ,jt.end_time EndedAt
  ,DATEDIFF(SECOND, jt.start_time, jt.end_time) DurationSeconds
  ,CASE
     WHEN DATEDIFF(SECOND, jt.start_time, jt.end_time) < 90 
       THEN FORMAT(DATEDIFF(SECOND, jt.start_time, jt.end_time), 'N0') + ' seconds'
     WHEN DATEDIFF(SECOND, jt.start_time, jt.end_time) < 3600 
       THEN FORMAT(DATEDIFF(SECOND, jt.start_time, jt.end_time) / 60.0, 'N1') + ' minutes'
     ELSE FORMAT(DATEDIFF(SECOND, jt.start_time, jt.end_time) / 60.0 / 60.0, 'N1') + ' hours'
   END AS DurationDisplay
  ,CASE sjh.run_status
     WHEN 0 THEN 'Failed'
     WHEN 1 THEN 'Succeeded'
     WHEN 2 THEN 'Retry'
     WHEN 3 THEN 'Canceled'
     WHEN 4 THEN 'Step output'
     ELSE 'Unknown'
   END RunStatus
  ,sjh.retries_attempted RetriesAttempted
  ,sjh.sql_message_id SqlMessageId
  ,sjh.sql_severity SqlSeverity
  ,sjh.server Server
  ,pkgex.package_path PackagePath
  ,pkgex.execution_id ExecutionId
  ,CAST(CASE pkgex.status
     WHEN 1 THEN 'Created'
     WHEN 2 THEN 'Running'
     WHEN 3 THEN 'Cancelled'
     WHEN 4 THEN 'Failed'
     WHEN 5 THEN 'Pending'
     WHEN 6 THEN 'Ended Unexpectedly'
     WHEN 7 THEN 'Succeeded'
     WHEN 8 THEN 'Stopping'
     WHEN 9 THEN 'Completed'
   END AS nvarchar(20)) ExecutionStatus
  ,opemail.name OperatorEmailed
  ,opnet.name OperatorNetSent
  ,oppage.name OperatorPaged
FROM msdb.dbo.sysjobhistory sjh
INNER JOIN (
  SELECT job_id, MAX(instance_id) last_instance
  FROM msdb.dbo.sysjobhistory 
  WHERE step_id = 0  -- job outcomes only
  GROUP BY job_id
) last_inst ON last_inst.job_id = sjh.job_id and last_inst.last_instance = sjh.instance_id
OUTER APPLY (
  SELECT msdb.dbo.agent_datetime(sjh.run_date, sjh.run_time) AS start_time
    ,Dateadd(Second, sjh.run_duration % 100 + -- Seconds
     (((sjh.run_duration / 100) % 100) * 60) + -- Minutes
     ((sjh.run_duration / 10000) * 60 * 60), -- Hours
     msdb.dbo.agent_datetime(sjh.run_date, sjh.run_time)) AS end_time
) jt
LEFT JOIN msdb.dbo.sysjobs j ON j.job_id = sjh.job_id
LEFT JOIN msdb.dbo.sysjobsteps step ON sjh.job_id = step.job_id and sjh.step_id = step.step_id
LEFT JOIN (
  SELECT CAST(folder_name + '\' + project_name + '\' + package_name AS nvarchar(500)) package_path
    ,CAST(start_time as datetime) start_time
    ,CAST(end_time as datetime) end_time
    ,execution_id
    ,status
  FROM SSISDB.catalog.executions
) pkgex ON step.command LIKE '%' + pkgex.package_path + '%'
           AND pkgex.start_time >= jt.start_time and pkgex.end_time <= jt.end_time
           and step.subsystem = 'SSIS'
LEFT JOIN msdb.dbo.sysoperators opemail ON opemail.id = sjh.operator_id_emailed
LEFT JOIN msdb.dbo.sysoperators opnet ON opnet.id = sjh.operator_id_netsent
LEFT JOIN msdb.dbo.sysoperators oppage ON oppage.id = sjh.operator_id_paged
WHERE sjh.run_status IN (0,3)  -- failed, cancelled
ORDER BY jt.start_time DESC;

SET @Count = @@ROWCOUNT;
