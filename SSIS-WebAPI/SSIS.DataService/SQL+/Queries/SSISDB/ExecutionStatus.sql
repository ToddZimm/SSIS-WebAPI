--+SqlPlusRoutine
    --&SelectType=MultiRow
    --&Comment=Returns execution status values and descriptions
    --&Author=Todd Zimmerman
--+SqlPlusRoutine

WITH val AS (
  SELECT CAST(1 AS int) AS [Value]
  UNION ALL
  SELECT [Value] + 1
  FROM val
  WHERE [Value] < 9
)
SELECT [Value]
  ,CAST(CASE [Value]
     WHEN 1 THEN 'Created'
     WHEN 2 THEN 'Running'
     WHEN 3 THEN 'Canceled'
     WHEN 4 THEN 'Failed'
     WHEN 5 THEN 'Pending'
     WHEN 6 THEN 'Ended Unexpectedly'
     WHEN 7 THEN 'Succeeded'
     WHEN 8 THEN 'Stopping'
     WHEN 9 THEN 'Completed'
   END AS nvarchar(20)) AS [Name]
  ,CAST(CASE [Value]
     WHEN 1 THEN 'Execution created'
     WHEN 2 THEN 'Execution running'
     WHEN 3 THEN 'Execution canceled'
     WHEN 4 THEN 'Execution failed'
     WHEN 5 THEN 'Execution pending'
     WHEN 6 THEN 'Execution ended unexpectedly'
     WHEN 7 THEN 'Execution succeeded'
     WHEN 8 THEN 'Execution stopping'
     WHEN 9 THEN 'Execution completed'
   END AS nvarchar(50)) AS [Description]
FROM val;