--+SqlPlusRoutine
    --&SelectType=MultiRow
    --&Comment=Returns summary execution statistics for each package in SSIS Catalog.
    --&Author=Todd Zimmerman
--+SqlPlusRoutine

--+Parameters
DECLARE 

    --+InOut
    --+Required
    --+Comment=Number of days to look back to calculate statistics.
    @LookbackDays int = 30,

    --+Output
    @Count int,

    --+Output
    @LookbackStartsAt  datetime,

    --+Output
    @LookbackEndsAt  datetime

--+Parameters

SET @LookbackEndsAt = GETDATE();
SET @LookbackStartsAt = DATEADD(DAY, -1 * @LookbackDays, @LookbackEndsAt);

SELECT p.package_id PackageId
  ,p.name PackageName
  ,pr.name ProjectName
  ,f.name FolderName
  ,ex.FirstExecutionStartedAt
  ,ex.LastExecutionStartedAt
  ,ISNULL(ex.ExecutionCount, 0) ExecutionCount
  ,ex.SuccessCount
  ,ex.FailedCount
  ,ex.AverageDurationSeconds
  ,ex.ShortestDurationSeconds
  ,ex.LongestDurationSeconds
FROM catalog.packages p
JOIN catalog.projects pr on pr.project_id = p.project_id
JOIN catalog.folders f on f.folder_id = pr.folder_id
LEFT JOIN (
  SELECT
    exc.package_name PackageName
   ,exc.project_name ProjectName
   ,exc.folder_name FolderName
   ,MIN(exc.start_time) AS FirstExecutionStartedAt
   ,MAX(exc.start_time) AS LastExecutionStartedAt
   ,COUNT(*) ExecutionCount
   ,SUM(CASE WHEN exc.status NOT IN(3, 4, 6) THEN 1 ELSE 0 END) SuccessCount
   ,SUM(CASE WHEN exc.status IN(3, 4, 6) THEN 1 ELSE 0 END) FailedCount
   ,AVG(DATEDIFF(SECOND, exc.start_time, exc.end_time)) AverageDurationSeconds
   ,MIN(DATEDIFF(SECOND, exc.start_time, exc.end_time)) ShortestDurationSeconds
   ,MAX(DATEDIFF(SECOND, exc.start_time, exc.end_time)) LongestDurationSeconds
  FROM catalog.executions exc
  WHERE exc.start_time >= @LookbackStartsAt
    AND exc.end_time IS NOT NULL
  GROUP BY exc.package_name, exc.project_name, exc.folder_name
) ex ON f.name = ex.FolderName AND pr.name = ex.ProjectName AND p.name = ex.PackageName
ORDER BY PackageId;

SET @Count = @@ROWCOUNT;

