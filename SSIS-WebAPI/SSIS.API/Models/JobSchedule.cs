namespace SSIS.API.Models
{
    public class JobSchedule
    {
        /// <summary>
        /// Unique ID for the schedule.
        /// </summary>
        public int? ScheduleId { set; get; }

        /// <summary>
        /// Schedule name.
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Job ID.
        /// </summary>
        public Guid? JobId { set; get; }

        /// <summary>
        /// Job name.
        /// </summary>
        public string JobName { set; get; }

        /// <summary>
        /// Unique GUID for the schedule.
        /// </summary>
        public Guid? ScheduleGuid { set; get; }

        /// <summary>
        /// Enabled status of the schedule.
        /// </summary>
        public string Status { set; get; } = string.Empty;

        /// <summary>
        /// Time of next scheduled run.
        /// </summary>
        public DateTime? NextRunAt { set; get; }

        /// <summary>
        /// Time the schedule will start.
        /// </summary>
        public TimeSpan? StartTime { set; get; }

        /// <summary>
        /// How frequently a job runs for this schedule.
        /// </summary>
        public string Frequency { set; get; }

        /// <summary>
        /// Days that the job is executed.
        /// </summary>
        public string FrequencyInterval { set; get; }

        /// <summary>
        /// Period between executions when run multiple times per day.
        /// </summary>
        public string SubDayFrequency { set; get; }

        /// <summary>
        /// Date the schedule becomes effective.
        /// </summary>
        public DateTime? ScheduleStartDate { set; get; }

        /// <summary>
        /// Date the schedule expires.
        /// </summary>
        public DateTime? ScheduleEndDate { set; get; }

        /// <summary>
        /// Time the schedule was created.
        /// </summary>
        public DateTime? CreatedAt { set; get; }

        /// <summary>
        /// Time the schedule was last modified.
        /// </summary>
        public DateTime? ModifiedAt { set; get; }
    }

    public class JobSchedules
    {
        public List<JobSchedule> Value { set; get; } = new();
    }
}
