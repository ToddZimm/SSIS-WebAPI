--+SqlPlusRoutine
    --&SelectType=MultiRow
    --&Comment=Returns summary execution statistics for each package in SSIS Catalog.
    --&Author=Todd Zimmerman
--+SqlPlusRoutine

--+Parameters
DECLARE 

    --+Default=30
    --+Comment=Number of days to look back to calculate statistics.
    @LookbackDays int = 30,

    --+Output
    @Count int

--+Parameters

SELECT pkg.package_id
  ,ex.package_name
  ,ex.project_name
  ,ex.folder_name
  ,MIN(ex.start_time) AS FirstExecutionStartedAt
  ,MAX(ex.start_time) AS LastExecutionStartedAt
  ,COUNT(*) ExecutionCount
  ,SUM(CASE WHEN ex.status NOT IN(3, 4, 6) THEN 1 ELSE 0 END) SuccessCount
  ,SUM(CASE WHEN ex.status IN(3, 4, 6) THEN 1 ELSE 0 END) FailedCount
  ,AVG(DATEDIFF(SECOND, start_time, end_time)) AverageDurationSeconds
  ,CASE
     WHEN AVG(DATEDIFF(SECOND, ex.start_time, ex.end_time)) < 90 
       THEN FORMAT(AVG(DATEDIFF(MILLISECOND, ex.start_time, ex.end_time)) / 1000.0, 'N1') + ' seconds'
     WHEN AVG(DATEDIFF(SECOND, ex.start_time, ex.end_time)) < 3600 
       THEN FORMAT(AVG(DATEDIFF(SECOND, ex.start_time, ex.end_time)) / 60.0, 'N1') + ' minutes'
     ELSE FORMAT(AVG(DATEDIFF(SECOND, ex.start_time, ex.end_time)) / 60.0 / 60.0, 'N1') + ' hours'
   END AS AverageDurationDisplay
FROM catalog.executions ex 
INNER JOIN (
  SELECT f.name folder_name, pr.name project_name, p.name package_name, p.package_id
  FROM catalog.packages p
  LEFT JOIN catalog.projects pr on pr.project_id = p.project_id
  LEFT JOIN catalog.folders f on f.folder_id = pr.folder_id
) pkg ON pkg.folder_name = ex.folder_name AND pkg.project_name = ex.project_name AND pkg.package_name = ex.package_name
WHERE start_time >= DATEADD(DAY, -1 * @LookbackDays, GETDATE())
GROUP BY pkg.package_id, ex.package_name, ex.project_name, ex.folder_name

SET @Count = @@ROWCOUNT;
