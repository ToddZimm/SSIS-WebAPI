namespace SSIS.API.Models
{
    public class PackageStatistic
    {
        /// <summary>
        /// Package ID.
        /// </summary>
        public long PackageId { set; get; }

        /// <summary>
        /// Name of the package.
        /// </summary>
        public string PackageName { set; get; } = string.Empty;

        /// <summary>
        /// Name of the project containing the package.
        /// </summary>
        public string ProjectName { set; get; } = string.Empty;

        /// <summary>
        /// Name of the folder containing the package.
        /// </summary>
        public string FolderName { set; get; } = string.Empty;

        /// <summary>
        /// Time the first execution started within the lookback period.
        /// </summary>
        public DateTimeOffset? FirstExecutionStartedAt { set; get; }

        /// <summary>
        /// Time the last execution started.
        /// </summary>
        public DateTimeOffset? LastExecutionStartedAt { set; get; }

        /// <summary>
        /// Number of package executions within the lookback period.
        /// </summary>
        public int ExecutionCount { set; get; } = 0;

        /// <summary>
        /// Number of successful executions within the lookback period.
        /// </summary>
        public int? SuccessCount { set; get; }

        /// <summary>
        /// Number of unsuccessful executions within the lookback period.
        /// </summary>
        public int? FailedCount { set; get; }

        /// <summary>
        /// Average duration of executions within the lookback period in seconds.
        /// </summary>
        public int? AverageDurationSeconds { set; get; }

        /// <summary>
        /// Shortest execution duration within the lookback period in seconds.
        /// </summary>
        public int? ShortestDurationSeconds { set; get; }

        /// <summary>
        /// Longest execution duration within the lookback period in seconds.
        /// </summary>
        public int? LongestDurationSeconds { set; get; }
    }

    public class PackageStatistics
    {
        public int LookbackDays { set; get; }
        public DateTime LookbackStartsAt { set; get; }
        public DateTime LookbackEndsAt { set; get; }
        public List<PackageStatistic> Value { set; get; } = new();
    }
}
