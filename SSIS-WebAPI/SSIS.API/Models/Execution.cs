namespace SSIS.API.Models
{
    public class Execution
    {
        public long ExecutionId { set; get; }

        public long PackageId { set; get; }

        public string FolderName { set; get; } = string.Empty;

        public string ProjectName { set; get; } = string.Empty;

        public string PackageName { set; get; } = string.Empty;

        public int StatusId { set; get; }

        public string StatusName { set; get; } = string.Empty;

        public string FirstErrorMessage { set; get; } = string.Empty;

        public DateTimeOffset? CreatedAt { set; get; }

        public DateTimeOffset? StartedAt { set; get; }

        public DateTimeOffset? EndedAt { set; get; }

        public string EnvironmentFolder { set; get; } = string.Empty;

        public string EnvironmentName { set; get; } = string.Empty;

        public string CalledBy { set; get; } = string.Empty;

        public string ExecutedAs { set; get; } = string.Empty;

        public string StoppedBy { set; get; } = string.Empty;

        public bool Use32BitRuntime { set; get; }

        public int? DurationSeconds { set; get; }

        public string DurationDisplay { set; get; } = string.Empty;

        public string ServerName { set; get; } = string.Empty;

        public List<ExecutionMessage>? Messages { set; get; }
    }

    public class Executions
    {
        public int? Page { get; set; }
        public int? PageSize { set; get; }
        public List<Execution> Value { set; get; } = new();
    }
}
