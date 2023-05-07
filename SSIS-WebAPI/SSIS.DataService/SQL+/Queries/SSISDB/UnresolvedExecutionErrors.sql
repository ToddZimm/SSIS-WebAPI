--+SqlPlusRoutine
    --&SelectType=MultiRow
    --&Comment=Returns list of packages where the last execution was not successful.
    --&Author=Todd Zimmerman
--+SqlPlusRoutine

--+Parameters

    DECLARE

    --+Output
    @Count int

--+Parameters

SELECT ex.execution_id ExecutionId
  ,pkg.package_id PackageId
  ,ex.folder_name FolderName
  ,ex.project_name ProjectName
  ,ex.package_name PackageName
  ,ex.status Status
  ,CAST(CASE ex.status
     WHEN 3 THEN 'Cancelled'
     WHEN 4 THEN 'Failed'
     WHEN 6 THEN 'Ended Unexpectedly'
   END AS nvarchar(20)) StatusName
  ,(SELECT TOP(1) em.message
    FROM catalog.event_messages em
    WHERE message_type IN(120, 130) -- Error, Task Failed
      AND em.operation_id = ex.execution_id
    order by message_time, event_message_id
   ) FirstErrorMessage
  ,ex.created_time CreatedTime
  ,ex.start_time StartTime
  ,ex.end_time EndTime
  ,ex.environment_folder_name EnvironmentFolder
  ,ex.environment_name EnvironmentName
  ,ex.caller_name Caller
  ,ex.executed_as_name ExecutedAs
  ,ex.stopped_by_name StoppedBy
  ,ex.use32bitruntime Use32BitRuntime
  ,DATEDIFF(SECOND, ex.start_time, ex.end_time) DurationSeconds
  ,CASE
     WHEN DATEDIFF(SECOND, ex.start_time, ex.end_time) < 90 
       THEN FORMAT(DATEDIFF(SECOND, ex.start_time, ex.end_time), 'N0') + ' seconds'
     WHEN DATEDIFF(SECOND, ex.start_time, ex.end_time) < 3600 
       THEN FORMAT(DATEDIFF(SECOND, ex.start_time, ex.end_time) / 60.0, 'N1') + ' minutes'
     ELSE FORMAT(DATEDIFF(SECOND, ex.start_time, ex.end_time) / 60.0 / 60.0, 'N1') + ' hours'
   END AS DurationDisplay
FROM catalog.executions ex 
INNER JOIN (
	SELECT folder_name, project_name, package_name, max(execution_id) last_execution_id
	FROM catalog.executions
	GROUP BY folder_name, project_name, package_name) lastexec on ex.execution_id = lastexec.last_execution_id
INNER JOIN (
  SELECT f.name folder_name, pr.name project_name, p.name package_name, p.package_id
  FROM catalog.packages p
  LEFT JOIN catalog.projects pr on pr.project_id = p.project_id
  LEFT JOIN catalog.folders f on f.folder_id = pr.folder_id
) pkg ON pkg.folder_name = ex.folder_name AND pkg.project_name = ex.project_name AND pkg.package_name = ex.package_name
WHERE ex.status IN(3, 4, 6);  --canceled (3), failed (4), ended unexpectedly (6)


SET @Count = @@ROWCOUNT;
