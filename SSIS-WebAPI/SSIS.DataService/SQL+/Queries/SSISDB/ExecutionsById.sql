--+SqlPlusRoutine
    --&SelectType=SingleRow
    --&Comment=Returns Execution details by ID in the SSIS Catalog
    --&Author=Todd Zimmerman
--+SqlPlusRoutine

--+Parameters

    DECLARE

    --+Required
    @Id int = 10,

    --+Output
    @ReturnValue int

--+Parameters

SELECT ex.execution_id ExecutionId
  ,ISNULL(pkg.package_id, 0) PackageId
  ,ex.folder_name FolderName
  ,ex.project_name ProjectName
  ,ex.package_name PackageName
  ,ex.status StatusId
  ,CAST(CASE ex.status
     WHEN 1 THEN 'Created'
     WHEN 2 THEN 'Running'
     WHEN 3 THEN 'Cancelled'
     WHEN 4 THEN 'Failed'
     WHEN 5 THEN 'Pending'
     WHEN 6 THEN 'Ended Unexpectedly'
     WHEN 7 THEN 'Succeeded'
     WHEN 8 THEN 'Stopping'
     WHEN 9 THEN 'Completed'
   END AS nvarchar(20)) StatusName
  ,(SELECT TOP(1) em.message
    FROM catalog.event_messages em
    WHERE message_type IN(120, 130) -- Error, Task Failed
      AND em.operation_id = ex.execution_id
    order by message_time, event_message_id
   ) FirstErrorMessage
  ,ex.created_time CreatedAt
  ,ex.start_time StartedAt
  ,ex.end_time EndedAt
  ,ex.environment_folder_name EnvironmentFolder
  ,ex.environment_name EnvironmentName
  ,ex.caller_name CalledBy
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
LEFT JOIN (
  SELECT f.name folder_name, pr.name project_name, p.name package_name, p.package_id
  FROM catalog.packages p
  LEFT JOIN catalog.projects pr on pr.project_id = p.project_id
  LEFT JOIN catalog.folders f on f.folder_id = pr.folder_id
) pkg ON pkg.folder_name = ex.folder_name AND pkg.project_name = ex.project_name AND pkg.package_name = ex.package_name
WHERE ex.execution_id = @Id

IF @@ROWCOUNT = 0
BEGIN
    --+Return=NotFound
    SET @ReturnValue=0;
END;
ELSE
BEGIN
    --+ReturnValue=Ok
    SET @ReturnValue = 1;
END;