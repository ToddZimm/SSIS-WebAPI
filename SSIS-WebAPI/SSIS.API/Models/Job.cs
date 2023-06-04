namespace SSIS.API.Models
{
    public class Job
    {
        /// <summary>
        /// Unique ID of the job.
        /// </summary>
        public Guid JobId { set; get; }

        /// <summary>
        /// Job name.
        /// </summary>
        public string Name { set; get; } = string.Empty;

        /// <summary>
        /// Server from which the job came.
        /// </summary>
        public string ServerName { set; get; } = string.Empty;

        /// <summary>
        /// Name of the job owner.
        /// </summary>
        public string OwnerName { set; get; } = string.Empty;

        /// <summary>
        /// Status of the job (Enabled, Disabled, Not Scheduled).
        /// </summary>
        public string Status { set; get; } = string.Empty;

        /// <summary>
        /// Description of the job.
        /// </summary>
        public string Description { set; get; } = string.Empty;

        /// <summary>
        /// Job category.
        /// </summary>
        public string Category { set; get; } = string.Empty;

        /// <summary>
        /// Date and time job created.
        /// </summary>
        public DateTime CreatedAt { set; get; }

        /// <summary>
        /// Date and time job last modified.
        /// </summary>
        public DateTime ModifiedAt { set; get; }

        /// <summary>
        /// Number of total schedules for the job.
        /// </summary>
        public int ScheduleCount { set; get; } = 0;

        /// <summary>
        /// Number of enabled schedules for the job.
        /// </summary>
        public int EnabledScheduleCount { set; get; } = 0;

        /// <summary>
        /// Number of steps in the job.
        /// </summary>
        public int StepCount { set; get; } = 0;

        /// <summary>
        /// Number of SSIS steps in the job.
        /// </summary>
        public int SSISStepCount { set; get; } = 0;

        ///<summary>
        /// Job steps
        ///</summary>
        public List<JobStep> Steps { set; get; } = new();
        public List<JobSchedule> Schedules { set; get; } = new();
    }

    public class Jobs
    {
        public List<Job> Value { set; get; } = new();
    }
}
