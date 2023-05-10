--+SqlPlusRoutine
    --&SelectType=MultiRow
    --&Comment=Returns list of SQL Agent Jobs on the server.
    --&Author=Todd Zimmerman
--+SqlPlusRoutine

--+Parameters

    DECLARE

    --+Output
    @Count int

--+Parameters

SELECT
  job.job_id JobId,
  job.name Name,
  svr.name ServerName,
  l.name OwnerName,
  CASE 
    WHEN job.enabled = 0 THEN 'Disabled'
    WHEN Sched.EnabledScheduleCount = 0 THEN 'Not Scheduled'
    WHEN job.enabled = 1 THEN 'Enabled'
  END Status,
  job.description Description,
  category.name Category,
  job.date_created CreatedAt,
  job.date_modified ModifiedAt,
  COALESCE(Sched.ScheduleCount, 0) ScheduleCount,
  COALESCE(sched.EnabledScheduleCount, 0) EnabledScheduleCount,
  COALESCE(Steps.StepCount, 0) StepCount,
  COALESCE(Steps.SSISStepCount, 0) SSISStepCount
FROM msdb.dbo.sysjobs AS job
LEFT JOIN msdb.sys.servers AS svr ON job.originating_server_id = svr.server_id
LEFT JOIN msdb.dbo.syscategories AS category ON job.category_id = category.category_id
LEFT JOIN msdb.sys.syslogins l ON job.owner_sid = l.sid
LEFT JOIN (
  SELECT job_id, COUNT(step_id) StepCount,
    SUM(CASE WHEN subsystem = 'SSIS' AND command LIKE '/ISSERVER%' THEN 1 ELSE 0 END) SSISStepCount
  FROM msdb.dbo.sysjobsteps 
  GROUP BY job_id
) Steps ON job.job_id = Steps.job_id
LEFT JOIN (
  SELECT js.job_id, COUNT(js.schedule_id) ScheduleCount, SUM(s.enabled) EnabledScheduleCount
  FROM msdb.dbo.sysjobschedules js
  LEFT JOIN msdb.dbo.sysschedules s ON s.schedule_id = js.schedule_id
  GROUP BY js.job_id
) Sched ON job.job_id = Sched.job_id

SET @Count = @@ROWCOUNT;
