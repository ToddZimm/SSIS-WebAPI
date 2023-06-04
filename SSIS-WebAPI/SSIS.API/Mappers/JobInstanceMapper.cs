using SSIS.API.Models;
using SSIS.DataService.SQLAgent.Models;

namespace SSIS.API.Mappers
{
    public static class JobInstanceMapper
    {
        public static JobInstance Map(JobInstancesResult result)
        {
            JobInstance jobInstance = new() 
            { 
                InstanceId = result.InstanceId,
                ParentInstanceId = result.ParentInstanceId,
                JobId = result.JobId,
                JobName = result.JobName,
                StepSequenceId = result.StepSequenceId,
                StepName = result.StepName,
                Subsystem = result.Subsystem,
                Command = result.Command,
                Message = result.Message,
                StartedAt = result.StartedAt,
                EndedAt = result.EndedAt,
                DurationSeconds = result.DurationSeconds,
                DurationDisplay = result.DurationDisplay,
                RunStatusId = result.RunStatusId,
                RunStatusName = result.RunStatusName,
                RetriesAttempted = result.RetriesAttempted,
                SqlMessageId = result.SqlMessageId,
                SqlSeverity = result.SqlSeverity,
                Server = result.Server,
                OperatorEmailed = result.OperatorEmailed,
                OperatorNetSent = result.OperatorNetSent,
                OperatorPaged = result.OperatorPaged
            };

            return jobInstance;
        }

        public static JobInstance Map(JobInstancesByIdResult result)
        {
            JobInstance jobInstance = new()
            {
                InstanceId = result.InstanceId,
                ParentInstanceId = result.ParentInstanceId,
                JobId = result.JobId,
                JobName = result.JobName,
                StepSequenceId = result.StepSequenceId,
                StepName = result.StepName,
                Subsystem = result.Subsystem,
                Command = result.Command,
                Message = result.Message,
                StartedAt = result.StartedAt,
                EndedAt = result.EndedAt,
                DurationSeconds = result.DurationSeconds,
                DurationDisplay = result.DurationDisplay,
                RunStatusId = result.RunStatusId,
                RunStatusName = result.RunStatusName,
                RetriesAttempted = result.RetriesAttempted,
                SqlMessageId = result.SqlMessageId,
                SqlSeverity = result.SqlSeverity,
                Server = result.Server,
                OperatorEmailed = result.OperatorEmailed,
                OperatorNetSent = result.OperatorNetSent,
                OperatorPaged = result.OperatorPaged
            };

            return jobInstance;
        }

        public static JobInstances MapList(List<JobInstancesResult> results)
        {
            JobInstances jobInstances = new()
            {
                Value = new()
            };

            foreach (JobInstancesResult result in results) 
            {
                jobInstances.Value.Add(new JobInstance()
                {
                    InstanceId = result.InstanceId,
                    ParentInstanceId = result.ParentInstanceId,
                    JobId = result.JobId,
                    JobName = result.JobName,
                    StepSequenceId = result.StepSequenceId,
                    StepName = result.StepName,
                    Subsystem = result.Subsystem,
                    Command = result.Command,
                    Message = result.Message,
                    StartedAt = result.StartedAt,
                    EndedAt = result.EndedAt,
                    DurationSeconds = result.DurationSeconds,
                    DurationDisplay = result.DurationDisplay,
                    RunStatusId = result.RunStatusId,
                    RunStatusName = result.RunStatusName,
                    RetriesAttempted = result.RetriesAttempted,
                    SqlMessageId = result.SqlMessageId,
                    SqlSeverity = result.SqlSeverity,
                    Server = result.Server,
                    OperatorEmailed = result.OperatorEmailed,
                    OperatorNetSent = result.OperatorNetSent,
                    OperatorPaged = result.OperatorPaged
                });
            }

            return jobInstances;
        }

        public static JobInstances MapList(List<UnresolvedJobErrorsResult> results)
        {
            JobInstances jobInstances = new()
            {
                Value = new()
            };

            foreach (var result in results)
            {
                jobInstances.Value.Add(new JobInstance()
                {
                    InstanceId = result.InstanceId,
                    ParentInstanceId = result.ParentInstanceId,
                    JobId = result.JobId,
                    JobName = result.JobName,
                    StepSequenceId = result.StepSequenceId,
                    StepName = result.StepName,
                    Subsystem = result.Subsystem,
                    Command = result.Command,
                    Message = result.Message,
                    StartedAt = result.StartedAt,
                    EndedAt = result.EndedAt,
                    DurationSeconds = result.DurationSeconds,
                    DurationDisplay = result.DurationDisplay,
                    RunStatusId = result.RunStatusId,
                    RunStatusName = result.RunStatusName,
                    RetriesAttempted = result.RetriesAttempted,
                    SqlMessageId = result.SqlMessageId,
                    SqlSeverity = result.SqlSeverity,
                    Server = result.Server,
                    OperatorEmailed = result.OperatorEmailed,
                    OperatorNetSent = result.OperatorNetSent,
                    OperatorPaged = result.OperatorPaged
                });
            }

            return jobInstances;
        }
    }
}
