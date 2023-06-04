--+SqlPlusRoutine
    --&SelectType=MultiRow
    --&Comment=Returns list of job instances ordered by most recent.
    --&Author=Todd Zimmerman
--+SqlPlusRoutine

--+Parameters

    DECLARE

    --+InOut
    --+Default=1
    --+Comment=Page number
    @Page int,

    --+InOut
    --+Range=10,100
	--+Default=25
	--+Comment=Number of records per page to return
    @PageSize int,
   
    --+Comment=Provide a Job ID to filter results
    @JobId uniqueidentifier,

    --+Comment=Return all step instances related to a job outcome
    @ParentInstanceId bigint,

    --+Comment=Return only job outcome without step details
    --+Default=true
    @OutcomeOnly bit,

    --+Comment=Provide a status value to filter results
    @RunStatusId int,

    --+Comment=Start date and time to filter results
    @StartTime datetime,

    --+Comment=End data and time to filter results
    @EndTime datetime,

     --+Output
    @Count int

--+Parameters

SET @Page = ISNULL(@Page, 1);
SET @PageSize = ISNULL(@PageSize, 25);
SET @RunStatusId = ISNULL(@RunStatusId, 0);
SET @OutcomeOnly = ISNULL(@OutcomeOnly, 0);

SELECT sjh.instance_id InstanceId
  ,ISNULL(parent.ParentInstanceId, sjh.instance_id) ParentInstanceId
  ,sjh.job_id JobId
  ,j.name JobName
  ,sjh.step_id StepSequenceId
  ,sjh.step_name StepName
  ,step.subsystem Subsystem
  ,step.command Command
  ,pkg.PackageId SSISPackageId
  ,pkg.package_path SSISPackagePath
  ,ex.execution_id SSISExecutionId
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
  ,sjh.run_status RunStatusId
  ,CASE sjh.run_status
     WHEN 0 THEN 'Failed'
     WHEN 1 THEN 'Succeeded'
     WHEN 2 THEN 'Retry'
     WHEN 3 THEN 'Canceled'
     WHEN 4 THEN 'Step output'
     ELSE 'Unknown'
   END RunStatusName
  ,sjh.retries_attempted RetriesAttempted
  ,sjh.sql_message_id SqlMessageId
  ,sjh.sql_severity SqlSeverity
  ,sjh.server Server
  ,opemail.name OperatorEmailed
  ,opnet.name OperatorNetSent
  ,oppage.name OperatorPaged
FROM msdb.dbo.sysjobhistory sjh
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
  SELECT CAST(f.name + '\' + pr.name + '\' + p.name AS nvarchar(500)) package_path
    ,p.package_id PackageId
	,f.name FolderName
	,pr.name ProjectName
	,p.name PackageName
  FROM catalog.packages p
  JOIN catalog.projects pr on pr.project_id = p.project_id
  JOIN catalog.folders f on f.folder_id = pr.folder_id
) pkg ON step.command LIKE '%' + pkg.package_path + '%' AND step.subsystem = 'SSIS'
LEFT JOIN (
  SELECT jh1.instance_id, MIN(jh2.instance_id) ParentInstanceId
  FROM msdb.dbo.sysjobhistory jh1
  LEFT JOIN msdb.dbo.sysjobhistory jh2 ON
      jh1.job_id = jh2.job_id
      AND jh2.instance_id > jh1.instance_id
      AND jh2.step_id = 0
  WHERE jh1.step_id > 0
  GROUP BY jh1.instance_id
) parent ON parent.instance_id = sjh.instance_id
LEFT JOIN SSISDB.catalog.executions ex ON ex.folder_name = pkg.FolderName and ex.project_name = pkg.ProjectName and ex.package_name = pkg.PackageName
                                          AND CAST(ex.start_time AS datetime) >= jt.start_time and CAST(ex.end_time AS datetime) <= jt.end_time
LEFT JOIN msdb.dbo.sysoperators opemail ON opemail.id = sjh.operator_id_emailed
LEFT JOIN msdb.dbo.sysoperators opnet ON opnet.id = sjh.operator_id_netsent
LEFT JOIN msdb.dbo.sysoperators oppage ON oppage.id = sjh.operator_id_paged
WHERE (@JobId IS NULL OR sjh.job_id = @JobId)
  AND (@RunStatusId = 0 OR sjh.run_status = @RunStatusId)
  AND (@StartTime IS NULL OR jt.start_time >= @StartTime)
  AND (@EndTime IS NULL OR jt.start_time <= @EndTime)
  AND (@OutcomeOnly = 0 OR sjh.step_id = 0)
  AND (@ParentInstanceId IS NULL OR sjh.instance_id = @ParentInstanceId OR parent.ParentInstanceId = @ParentInstanceId)
ORDER BY jt.start_time DESC
OFFSET ((@Page - 1) * @PageSize) ROWS
FETCH NEXT @PageSize ROWS ONLY;

SET @Count = @@ROWCOUNT;
