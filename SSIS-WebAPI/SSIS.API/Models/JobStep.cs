namespace SSIS.API.Models
{
    public class JobStep
    {
        /// <summary>
        /// Internal StepId.
        /// </summary>
        public Guid StepId { set; get; }

        /// <summary>
        /// Name of the step.
        /// </summary>
        public string Name { set; get; } = string.Empty;

        /// <summary>
        /// JobID of the parent job.
        /// </summary>
        public Guid JobId { set; get; }

        /// <summary>
        /// Name of the parent job.
        /// </summary>
        public string JobName { set; get; } = string.Empty;

        /// <summary>
        /// Step sequence number.
        /// </summary>
        public int StepSequence { set; get; }

        /// <summary>
        /// Subsystem type of the step command.
        /// </summary>
        public string Subsystem { set; get; } = string.Empty;

        /// <summary>
        /// SSIS Package ID called by the step.
        /// </summary>
        public long? SSISPackageId { set; get; }

        /// <summary>
        /// Path to the SSIS package called by the step.
        /// </summary>
        public string SSISPackagePath { set; get; } = string.Empty;

        /// <summary>
        /// Command called by the step.
        /// </summary>
        public string Command { set; get; } = string.Empty;

        /// <summary>
        /// Database name for the step execution.
        /// </summary>
        public string DatabaseName { set; get; } = string.Empty;

        /// <summary>
        /// Database user name used to connect.
        /// </summary>
        public string DatabaseUserName { set; get; } = string.Empty;

        /// <summary>
        /// Proxy account used to run the step.
        /// </summary>
        public string ProxyName { set; get; } = string.Empty;

        /// <summary>
        /// Last run date and time.
        /// </summary>
        public DateTime? LastRunAt { set; get; }

        /// <summary>
        /// Last execution outcome.
        /// </summary>
        public string LastOutcome { set; get; } = string.Empty;

        /// <summary>
        /// Action to take when the step is successful.
        /// </summary>
        public string OnSuccessAction { set; get; } = string.Empty;

        /// <summary>
        /// Action to take when the step fails.
        /// </summary>
        public string OnFailAction { set; get; } = string.Empty;

        /// <summary>
        /// Number to times to retry the step on failure.
        /// </summary>
        public int RetryAttempts { set; get; } = 0;

        /// <summary>
        /// Interval between retry attemps in minutes.
        /// </summary>
        public int RetryIntervalMinutes { set; get; } = 0;
    }

    public class JobSteps
    {
        public List<JobStep> Value { set; get; } = new();
    }
}
