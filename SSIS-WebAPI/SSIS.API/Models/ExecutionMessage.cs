namespace SSIS.API.Models
{
    public class ExecutionMessage
    {
        public long? MessageId { set; get; }

        public long ExecutionId { set; get; }

        public DateTimeOffset CreatedAt { set; get; }

        public string Status { set; get; } = string.Empty;

        public string Message { set; get; } = string.Empty;

        public short MessageTypeId { set; get; }

        public string MessageTypeName { set; get; } = string.Empty;

        public short? MessageSourceId { set; get; }

        public string MessageSourceName { set; get; } = string.Empty;

        public string EventName { set; get; } = string.Empty;

        public string SubComponentName { set; get; } = string.Empty;

        public string ExecutionPath { set; get; } = string.Empty;
    }
}
