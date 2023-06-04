using SSIS.API.Models;
using SSIS.DataService.SQLAgent.Models;

namespace SSIS.API.Mappers
{
    public static class JobStepMapper
    {
        public static JobStep Map(JobStepsResult result)
        {
            JobStep jobStep = new JobStep() 
            { 
                StepId = result.StepId == null ? Guid.Empty : (Guid) result.StepId,
                Name = result.Name,
                JobId = result.JobId,
                JobName = result.JobName,
                StepSequence = result.StepSequenceId,
                Subsystem = result.Subsystem,
                SSISPackageId = result. SSISPackageId,
                SSISPackagePath = result.SSISPackagePath,
                Command = result.Command,
                DatabaseName = result.DatabaseName,
                DatabaseUserName = result.DatabaseUserName,
                ProxyName = result.ProxyName,
                LastRunAt = result.LastRunAt,
                LastOutcome = result.LastOutcome,
                OnSuccessAction = result.OnSuccessAction,
                OnFailAction = result.OnFailAction,
                RetryAttempts = result.RetryAttempts,
                RetryIntervalMinutes = result.RetryIntervalMinutes
            };

            return jobStep;
        }

        public static JobSteps MapList(List<JobStepsResult> results)
        {
            JobSteps jobSteps = new()
            {
                Value = new()
            };

            foreach (JobStepsResult result in results)
            {
                jobSteps.Value.Add(new JobStep()
                {
                    StepId = result.StepId == null ? Guid.Empty : (Guid)result.StepId,
                    Name = result.Name,
                    JobId = result.JobId,
                    JobName = result.JobName,
                    StepSequence = result.StepSequenceId,
                    Subsystem = result.Subsystem,
                    SSISPackageId = result.SSISPackageId,
                    SSISPackagePath = result.SSISPackagePath,
                    Command = result.Command,
                    DatabaseName = result.DatabaseName,
                    DatabaseUserName = result.DatabaseUserName,
                    ProxyName = result.ProxyName,
                    LastRunAt = result.LastRunAt,
                    LastOutcome = result.LastOutcome,
                    OnSuccessAction = result.OnSuccessAction,
                    OnFailAction = result.OnFailAction,
                    RetryAttempts = result.RetryAttempts,
                    RetryIntervalMinutes = result.RetryIntervalMinutes
                });
            }

            return jobSteps;
        }
    }
}
