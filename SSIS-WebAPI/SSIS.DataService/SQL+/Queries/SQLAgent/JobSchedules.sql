--+SqlPlusRoutine
    --&SelectType=MultiRow
    --&Comment=Returns list of schedules for a job.
    --&Author=Todd Zimmerman
--+SqlPlusRoutine

--+Parameters

    DECLARE

    --+InOut
    --+Required
    @JobId uniqueidentifier,

    --+Output
    @Count int

--+Parameters

SELECT sched.schedule_id ScheduleId
  ,sched.name Name
  ,jobsched.job_id JobId
  ,j.name JobName
  ,sched.schedule_uid ScheduleGuid
  ,CASE sched.enabled
    WHEN 1
      THEN 'Enabled'
    ELSE 'Disabled'
    END [Status]
  ,CASE
     WHEN jobsched.next_run_date > 0 
       THEN CAST(
	        STUFF(STUFF(CAST(jobsched.next_run_date AS CHAR(8)), 5, 0, '-'), 8, 0, '-') + ' ' + 
	        STUFF(STUFF(RIGHT('000000' + CAST(jobsched.next_run_time AS VARCHAR(6)), 6), 3, 0, ':'), 6, 0, ':')
	     AS datetime)
     ELSE CAST(NULL AS datetime)
   END NextRunAt
  ,CAST(STUFF(STUFF(RIGHT('000000' + CAST(sched.active_start_time AS VARCHAR(6)), 6), 3, 0, ':'), 6, 0, ':') AS time) AS StartTime
  ,CASE sched.freq_type
    WHEN 1
      THEN 'Once'
    WHEN 4
      THEN 'Daily'
    WHEN 8
      THEN 'Weekly'
    WHEN 16
      THEN CASE sched.freq_recurrence_factor
          WHEN 1
            THEN 'Monthly'
          ELSE 'Every ' + CONVERT(VARCHAR(10), sched.freq_recurrence_factor) + ' Months'
          END
    WHEN 32
      THEN 'Monthly relative'
    WHEN 64
      THEN 'When SQL Server Agent starts'
    WHEN 128
      THEN 'When computer is idle'
    END AS Frequency
  ,CASE sched.freq_type
    WHEN 1
      THEN 'On ' + LEFT(CONVERT(VARCHAR(10), jobsched.next_run_date), 4) + '-' + SUBSTRING(CONVERT(VARCHAR(10), jobsched.next_run_date), 5, 2) + '-' + RIGHT(CONVERT(VARCHAR(10), jobsched.next_run_date), 2)
    WHEN 4
      THEN 'Every ' + CONVERT(VARCHAR(10), sched.freq_interval) + ' day(s)'
    WHEN 8
      THEN 'Every ' + CONVERT(VARCHAR, sched.freq_recurrence_factor) + ' week(s) on ' + LEFT(CASE 
            WHEN sched.freq_interval & 1 = 1
              THEN 'Sunday, '
            ELSE ''
            END + CASE 
            WHEN sched.freq_interval & 2 = 2
              THEN 'Monday, '
            ELSE ''
            END + CASE 
            WHEN sched.freq_interval & 4 = 4
              THEN 'Tuesday, '
            ELSE ''
            END + CASE 
            WHEN sched.freq_interval & 8 = 8
              THEN 'Wednesday, '
            ELSE ''
            END + CASE 
            WHEN sched.freq_interval & 16 = 16
              THEN 'Thursday, '
            ELSE ''
            END + CASE 
            WHEN sched.freq_interval & 32 = 32
              THEN 'Friday, '
            ELSE ''
            END + CASE 
            WHEN sched.freq_interval & 64 = 64
              THEN 'Saturday, '
            ELSE ''
            END, LEN(CASE 
              WHEN sched.freq_interval & 1 = 1
                THEN 'Sunday, '
              ELSE ''
              END + CASE 
              WHEN sched.freq_interval & 2 = 2
                THEN 'Monday, '
              ELSE ''
              END + CASE 
              WHEN sched.freq_interval & 4 = 4
                THEN 'Tuesday, '
              ELSE ''
              END + CASE 
              WHEN sched.freq_interval & 8 = 8
                THEN 'Wednesday, '
              ELSE ''
              END + CASE 
              WHEN sched.freq_interval & 16 = 16
                THEN 'Thursday, '
              ELSE ''
              END + CASE 
              WHEN sched.freq_interval & 32 = 32
                THEN 'Friday, '
              ELSE ''
              END + CASE 
              WHEN sched.freq_interval & 64 = 64
                THEN 'Saturday, '
              ELSE ''
              END) - 1)
    WHEN 16
      THEN 'Day ' + CONVERT(VARCHAR, sched.freq_interval)
    WHEN 32
      THEN 'The ' + CASE sched.freq_relative_interval
          WHEN 1
            THEN 'First'
          WHEN 2
            THEN 'Second'
          WHEN 4
            THEN 'Third'
          WHEN 8
            THEN 'Fourth'
          WHEN 16
            THEN 'Last'
          END + CASE sched.freq_interval
          WHEN 1
            THEN ' Sunday'
          WHEN 2
            THEN ' Monday'
          WHEN 3
            THEN ' Tuesday'
          WHEN 4
            THEN ' Wednesday'
          WHEN 5
            THEN ' Thursday'
          WHEN 6
            THEN ' Friday'
          WHEN 7
            THEN ' Saturday'
          WHEN 8
            THEN ' Day'
          WHEN 9
            THEN ' Weekday'
          WHEN 10
            THEN ' Weekend Day'
          END + ' of every ' + CONVERT(VARCHAR, sched.freq_recurrence_factor) + ' month(s)'
    ELSE ''
    END AS FrequencyInterval
  ,CASE sched.freq_subday_type
    WHEN 1
      THEN 'Once'
    WHEN 2
      THEN 'Every ' + CONVERT(VARCHAR, sched.freq_subday_interval) + ' Seconds(s) between ' + STUFF(STUFF(RIGHT('000000' + CONVERT(VARCHAR(8), sched.active_start_time), 6), 5, 0, ':'), 3, 0, ':') + ' and ' + STUFF(STUFF(RIGHT('000000' + CONVERT(VARCHAR(8), sched.active_end_time), 6), 5, 0, ':'), 3, 0, ':')
    WHEN 4
      THEN 'Every ' + CONVERT(VARCHAR, sched.freq_subday_interval) + ' Minute(s) between ' + STUFF(STUFF(RIGHT('000000' + CONVERT(VARCHAR(8), sched.active_start_time), 6), 5, 0, ':'), 3, 0, ':') + ' and ' + STUFF(STUFF(RIGHT('000000' + CONVERT(VARCHAR(8), sched.active_end_time), 6), 5, 0, ':'), 3, 0, ':')
    WHEN 8
      THEN 'Every ' + CONVERT(VARCHAR, sched.freq_subday_interval) + ' Hour(s) between ' + STUFF(STUFF(RIGHT('000000' + CONVERT(VARCHAR(8), sched.active_start_time), 6), 5, 0, ':'), 3, 0, ':') + ' and ' + STUFF(STUFF(RIGHT('000000' + CONVERT(VARCHAR(8), sched.active_end_time), 6), 5, 0, ':'), 3, 0, ':')
    ELSE ''
    END AS SubDayFrequency
  ,CAST(LEFT(CONVERT(VARCHAR(10), sched.active_start_date), 4) + '-' + SUBSTRING(CONVERT(VARCHAR(10), sched.active_start_date), 5, 2) + '-' + RIGHT(CONVERT(VARCHAR(10), sched.active_start_date), 2) AS DATE) ScheduleStartDate
  ,CAST(CASE 
      WHEN sched.active_end_date = '99991231'
        THEN NULL
      ELSE LEFT(CONVERT(VARCHAR(10), sched.active_end_date), 4) + '-' + SUBSTRING(CONVERT(VARCHAR(10), sched.active_end_date), 5, 2) + '-' + RIGHT(CONVERT(VARCHAR(10), sched.active_end_date), 2)
      END AS DATE) ScheduleEndDate
  ,sched.date_created CreatedAt
  ,sched.date_modified ModifiedAt
FROM msdb.dbo.sysjobschedules jobsched WITH (NOLOCK)
LEFT JOIN msdb.dbo.sysschedules sched WITH (NOLOCK) ON sched.schedule_id = jobsched.schedule_id
LEFT JOIN msdb.dbo.sysjobs j WITH (NOLOCK) ON j.job_id = jobsched.job_id
WHERE jobsched.job_id = @JobId
ORDER BY NextRunAt;

SET @Count = @@ROWCOUNT;
