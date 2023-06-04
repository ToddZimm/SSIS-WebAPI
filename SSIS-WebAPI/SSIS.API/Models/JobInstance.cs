namespace SSIS.API.Models
{
    public class JobInstance
    {
        /// <summary>
        /// Unique identifier for the job instance.
        /// </summary>
        public int InstanceId { set; get; }

        /// <summary>
        /// Unique identifier for the parent job outcome instance.
        /// </summary>
        public int ParentInstanceId { set; get; }

        /// <summary>
        /// Job ID.
        /// </summary>
        public Guid JobId { set; get; }

        /// <summary>
        /// Job name.
        /// </summary>
        public string JobName { set; get; } = string.Empty;

        /// <summary>
        /// ID of the step in the job.
        /// </summary>
        public int StepSequenceId { set; get; }

        /// <summary>
        /// Step name.
        /// </summary>
        public string StepName { set; get; } = string.Empty;

        /// <summary>
        /// Name of the subsystem used by SQL Server Agent to execute the job step.
        /// </summary>
        public string Subsystem { set; get; } = string.Empty;

        /// <summary>
        /// Command to be executed by subsystem.
        /// </summary>
        public string Command { set; get; } = string.Empty;

        /// <summary>
        /// Text, if any, of a SQL Server error.
        /// </summary>
        public string Message { set; get; } = string.Empty;

        /// <summary>
        /// Date and time the job or step started execution.
        /// </summary>
        public DateTime? StartedAt { set; get; }

        /// <summary>
        /// Date and time the job or step finished execution.
        /// </summary>
        public DateTime? EndedAt { set; get; }

        /// <summary>
        /// Run duration in seconds.
        /// </summary>
        public int? DurationSeconds { set; get; }

        /// <summary>
        /// Duration display string.
        /// </summary>
        public string DurationDisplay { set; get; } = string.Empty;
        
        /// <summary>
        /// SQL Agent run status ID.
        /// </summary>
        public int RunStatusId { set; get; }

        /// <summary>
        /// Status of the job execution.
        /// </summary>
        public string RunStatusName { set; get; } = string.Empty;

        /// <summary>
        /// Number of retry attempts for the job or step.
        /// </summary>
        public int RetriesAttempted { set; get; }

        /// <summary>
        /// ID of any SQL Server error message returned if the job failed.
        /// </summary>
        public int SqlMessageId { set; get; }

        /// <summary>
        /// Severity of any SQL Server error.
        /// </summary>
        public int SqlSeverity { set; get; }

        /// <summary>
        /// Name of the server where the job was executed.
        /// </summary>
        public string Server { set; get; } = string.Empty;

        /// <summary>
        /// Operator notified by email when the job completed.
        /// </summary>
        public string OperatorEmailed { set; get; } = string.Empty;

        /// <summary>
        /// Operator notified by a message when the job completed.
        /// </summary>
        public string OperatorNetSent { set; get; } = string.Empty;

        /// <summary>
        /// Operator notified by pager when the job completed.
        /// </summary>
        public string OperatorPaged { set; get; } = string.Empty;
    }

    public class JobInstances
    {
        public int? Page { get; set; }
        public int? PageSize { set; get; }
        public List<JobInstance> Value { set; get; } = new();
    }
}
