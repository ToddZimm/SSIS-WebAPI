using SSIS.API.Models;
using SSIS.DataService.SSISDB.Models;

namespace SSIS.API.Mappers
{
    public static class ExecutionMapper
    {
        public static Execution Map (ExecutionsByIdResult executionsByIdResult, List<ExecutionMessagesResult> executionMessagesResults)
        {
            Execution execution = new() {
                ExecutionId = executionsByIdResult.ExecutionId,
                PackageId = executionsByIdResult.PackageId,
                FolderName = executionsByIdResult.FolderName,
                ProjectName = executionsByIdResult.ProjectName,
                PackageName = executionsByIdResult.PackageName,
                StatusId = executionsByIdResult.StatusId,
                StatusName = executionsByIdResult.StatusName,
                FirstErrorMessage = executionsByIdResult.FirstErrorMessage,
                CreatedAt = executionsByIdResult.CreatedAt,
                StartedAt = executionsByIdResult.StartedAt,
                EndedAt = executionsByIdResult.EndedAt,
                EnvironmentFolder = executionsByIdResult.EnvironmentFolder,
                EnvironmentName = executionsByIdResult.EnvironmentName,
                CalledBy = executionsByIdResult.CalledBy,
                ExecutedAs = executionsByIdResult.ExecutedAs,
                StoppedBy = executionsByIdResult.StoppedBy,
                Use32BitRuntime = executionsByIdResult.Use32BitRuntime,
                DurationSeconds = executionsByIdResult.DurationSeconds,
                DurationDisplay = executionsByIdResult.DurationDisplay,
                ServerName = executionsByIdResult.ServerName,
                Messages = new List<ExecutionMessage>(executionMessagesResults.Count)
            };

            foreach (var msg in executionMessagesResults)
            {
                execution.Messages.Add(new ExecutionMessage()
                {
                    MessageId = msg.MessageId,
                    ExecutionId = msg.ExecutionId,
                    CreatedAt = msg.CreatedAt,
                    Status = msg.Status,
                    Message = msg.Message,
                    MessageTypeId = msg.MessageTypeId,
                    MessageTypeName = msg.MessageTypeName,
                    MessageSourceId = msg.MessageSourceId,
                    MessageSourceName = msg.MessageSourceName,
                    EventName = msg.EventName,
                    SubComponentName = msg.SubComponentName,
                    ExecutionPath = msg.ExecutionPath
                });
            }

            return execution;
        }

        public static Executions MapList(ExecutionsOutput executionsOutput)
        {
            Executions executions = new()
            {
                Page = executionsOutput.Page,
                PageSize = executionsOutput.PageSize,
                Value = new List<Execution>(executionsOutput.ResultData.Count)
            };

            foreach (var exec in executionsOutput.ResultData)
            {
                executions.Value.Add(new Execution()
                {
                    ExecutionId = exec.ExecutionId,
                    PackageId = exec.PackageId,
                    FolderName = exec.FolderName,
                    ProjectName = exec.ProjectName,
                    PackageName = exec.PackageName,
                    StatusId = exec.StatusId,
                    StatusName = exec.StatusName,
                    FirstErrorMessage = exec.FirstErrorMessage,
                    CreatedAt = exec.CreatedAt,
                    StartedAt = exec.StartedAt,
                    EndedAt = exec.EndedAt,
                    EnvironmentFolder = exec.EnvironmentFolder,
                    EnvironmentName = exec.EnvironmentName,
                    CalledBy = exec.CalledBy,
                    ExecutedAs = exec.ExecutedAs,
                    StoppedBy = exec.StoppedBy,
                    Use32BitRuntime = exec.Use32BitRuntime,
                    DurationSeconds = exec.DurationSeconds,
                    DurationDisplay = exec.DurationDisplay,
                    ServerName = exec.ServerName,
                    Messages = new List<ExecutionMessage>()
                });
            }

           return executions;
        }

        public static Executions MapList (UnresolvedExecutionErrorsOutput output)
        {
            Executions executions = new()
            {
                Page = 1,
                PageSize = output.Count,
                Value = new List<Execution>()
            };
            
            foreach (var exec in output.ResultData)
            {
                executions.Value.Add(new Execution()
                {
                    ExecutionId = exec.ExecutionId,
                    PackageId = exec.PackageId,
                    FolderName = exec.FolderName,
                    ProjectName = exec.ProjectName,
                    PackageName = exec.PackageName,
                    StatusId = exec.StatusId,
                    StatusName = exec.StatusName,
                    FirstErrorMessage = exec.FirstErrorMessage,
                    CreatedAt = exec.CreatedAt,
                    StartedAt = exec.StartedAt,
                    EndedAt = exec.EndedAt,
                    EnvironmentFolder = exec.EnvironmentFolder,
                    EnvironmentName = exec.EnvironmentName,
                    CalledBy = exec.CalledBy,
                    ExecutedAs = exec.ExecutedAs,
                    StoppedBy = exec.StoppedBy,
                    Use32BitRuntime = exec.Use32BitRuntime,
                    DurationSeconds = exec.DurationSeconds,
                    DurationDisplay = exec.DurationDisplay,
                    ServerName = exec.ServerName,
                    Messages = new List<ExecutionMessage>()
                });
            }

            return executions;

        }
    }
}
