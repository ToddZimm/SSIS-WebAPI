﻿--+SqlPlusRoutine
    --&SelectType=MultiRow
    --&Comment=Returns list of SQL Agent job steps.
    --&Author=Todd Zimmerman
--+SqlPlusRoutine

--+Parameters

    DECLARE
    --+Comment=Job ID to filter results
    @JobId uniqueidentifier,

    --+Comment=SSIS Package ID called in step to filter results
    @PackageId int,

    --+Output
    @Count int

--+Parameters

SELECT step.step_uid StepId
  ,step.step_name Name
  ,step.job_id JobId
  ,job.name JobName
  ,step.step_id StepSequence
  ,step.subsystem Subsystem
  ,pkg.package_id SSISPackageId
  ,step.command Command
  ,step.database_name DatabaseName
  ,step.database_user_name DatabaseUserName
  ,prox.name ProxyName
  ,CAST(CAST(step.last_run_date AS CHAR(8))+' '+STUFF(STUFF(step.last_run_time,3,0,':'),6,0,':') AS DATETIME) LastRunAt
  ,CASE step.last_run_outcome
     WHEN 0 THEN 'Failed'
     WHEN 1 THEN 'Succeeded'
     WHEN 2 THEN 'Retry'
     WHEN 3 THEN 'Canceled'
     ELSE 'Unknown'
   END LastOutcome
  ,CASE step.on_success_action
     WHEN 1 THEN 'Quit with success'
     WHEN 2 THEN 'Quit with failure'
     WHEN 3 THEN 'Go to next step'
     WHEN 4 THEN 'Go to step ' + FORMAT(step.on_success_step_id, 'N0')
     ELSE 'Unknown'
   END OnSuccessAction
  ,CASE step.on_fail_action
     WHEN 1 THEN 'Quit with success'
     WHEN 2 THEN 'Quit with failure'
     WHEN 3 THEN 'Go to next step'
     WHEN 4 THEN 'Go to step ' + FORMAT(step.on_fail_step_id, 'N0')
     ELSE 'Unknown'
   END OnFailAction
  ,step.retry_attempts RetryAttempts
  ,step.retry_interval RetryIntervalMinutes
FROM msdb.dbo.sysjobsteps step
INNER JOIN msdb.dbo.sysjobs job on job.job_id = step.job_id
LEFT JOIN msdb.dbo.sysproxies prox ON step.proxy_id = prox.proxy_id
LEFT JOIN (
  SELECT 'SSISDB\' + f.name + '\' + pr.name + '\' + p.name package_path, p.package_id
  FROM catalog.packages p
  JOIN catalog.projects pr on pr.project_id = p.project_id
  JOIN catalog.folders f on f.folder_id = pr.folder_id
) pkg ON step.command LIKE '%' + pkg.package_path + '%'
WHERE (@JobId IS NULL OR step.job_id = @JobId)
  AND (@PackageId IS NULL OR pkg.package_id = @PackageId)
ORDER BY job.name, step.step_id;

SET @Count = @@ROWCOUNT;