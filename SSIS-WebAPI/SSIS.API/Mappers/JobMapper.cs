using Microsoft.AspNetCore.Cors.Infrastructure;
using SSIS.API.Models;
using SSIS.DataService.SQLAgent.Models;
using System.Diagnostics.Eventing.Reader;

namespace SSIS.API.Mappers
{
    public static class JobMapper
    {
        public static  Job Map (JobsByIdResult jobsResult, List<JobStepsResult> jobSteps, List<JobSchedulesResult> jobSchedules)
        {
            Job job = new()
            {
                JobId = jobsResult.JobId,
                Name = jobsResult.Name,
                ServerName = jobsResult.ServerName,
                OwnerName = jobsResult.OwnerName,
                Status = jobsResult.Status,
                Description = jobsResult.Description,
                Category = jobsResult.Category,
                CreatedAt = jobsResult.CreatedAt,
                ModifiedAt = jobsResult.ModifiedAt,
                ScheduleCount = jobsResult.ScheduleCount == null ? 0 : (int)jobsResult.ScheduleCount,
                EnabledScheduleCount = jobsResult.EnabledScheduleCount == null ? 0 : (int)jobsResult.EnabledScheduleCount,
                StepCount = jobsResult.StepCount == null ? 0 : (int)jobsResult.StepCount,
                SSISStepCount = jobsResult.SSISStepCount == null ? 0 : (int)jobsResult.SSISStepCount,
                Steps = new(),
                Schedules = new()
            };

            foreach (var step in jobSteps)
            {
                job.Steps.Add(new JobStep
                {
                    StepId = step.JobId,
                    Name = step.Name,
                    JobId = step.JobId,
                    JobName = step.JobName,
                    StepSequence = step.StepSequenceId,
                    Subsystem = step.Subsystem,
                    SSISPackageId = step.SSISPackageId,
                    SSISPackagePath = step.SSISPackagePath,
                    Command = step.Command,
                    DatabaseName = step.DatabaseName,
                    DatabaseUserName = step.DatabaseUserName,
                    ProxyName = step.ProxyName,
                    LastRunAt = step.LastRunAt,
                    LastOutcome = step.LastOutcome,
                    OnSuccessAction = step.OnSuccessAction,
                    OnFailAction = step.OnFailAction,
                    RetryAttempts = step.RetryAttempts,
                    RetryIntervalMinutes = step.RetryIntervalMinutes
                });
            }

            foreach (var sched in jobSchedules)
            {
                job.Schedules.Add(new JobSchedule
                {
                    ScheduleId = sched.ScheduleId,
                    Name = sched.Name,
                    JobId = sched.JobId,
                    JobName = sched.JobName,
                    ScheduleGuid = sched.ScheduleGuid,
                    Status = sched.Status,
                    NextRunAt = sched.NextRunAt,
                    StartTime = sched.StartTime,
                    Frequency = sched.Frequency,
                    FrequencyInterval = sched.FrequencyInterval,
                    SubDayFrequency = sched.SubDayFrequency,
                    ScheduleStartDate = sched.ScheduleStartDate,
                    ScheduleEndDate = sched.ScheduleEndDate,
                    CreatedAt = sched.CreatedAt,
                    ModifiedAt = sched.ModifiedAt
                });
            }

            return job;
        }

        public static Jobs MapList(List<JobsResult> jobsResults)
        {
            var jobs = new Jobs() { Value = new() };
            foreach (var job in jobsResults)
            {
                jobs.Value.Add(new()
                {
                    JobId = job.JobId,
                    Name = job.Name,
                    ServerName = job.ServerName,
                    OwnerName = job.OwnerName,
                    Status = job.Status,
                    Description = job.Description,
                    Category = job.Category,
                    CreatedAt = job.CreatedAt,
                    ModifiedAt = job.ModifiedAt,
                    ScheduleCount = job.ScheduleCount == null ? 0 : (int)job.ScheduleCount,
                    EnabledScheduleCount = job.EnabledScheduleCount == null ? 0 : (int)job.EnabledScheduleCount,
                    StepCount = job.StepCount == null ? 0 : (int)job.StepCount,
                    SSISStepCount = job.SSISStepCount == null ? 0 : (int)job.SSISStepCount,
                    Steps = new(),
                    Schedules = new()
                });
            }

            return jobs;
        }
    }
}
