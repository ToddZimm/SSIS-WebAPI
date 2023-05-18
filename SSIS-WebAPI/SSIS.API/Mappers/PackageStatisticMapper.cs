using SSIS.DataService.SSISDB.Models;
using SSIS.API.Models;

namespace SSIS.API.Mappers
{
    public static class PackageStatisticMapper
    {
        public static PackageStatistic Map (PackageExecutionSummaryResult packageSummary)
        {
            PackageStatistic result = new PackageStatistic() 
            { 
                PackageId = packageSummary.PackageId,
                PackageName = packageSummary.PackageName,
                ProjectName = packageSummary.ProjectName,
                FolderName = packageSummary.FolderName,
                FirstExecutionStartedAt = packageSummary.FirstExecutionStartedAt,
                LastExecutionStartedAt = packageSummary.LastExecutionStartedAt,
                ExecutionCount = packageSummary.ExecutionCount,
                SuccessCount = packageSummary.SuccessCount,
                FailedCount = packageSummary.FailedCount,
                AverageDurationSeconds = packageSummary.AverageDurationSeconds,
                ShortestDurationSeconds = packageSummary.ShortestDurationSeconds,
                LongestDurationSeconds = packageSummary.LongestDurationSeconds
            };

            return result;
        }

        public static PackageStatistics MapOutput(PackageExecutionSummaryOutput summaryOutput)
        {
            PackageStatistics result = new()
            {
                LookbackDays = (int)summaryOutput.LookbackDays,
                LookbackStartsAt = (DateTime)summaryOutput.LookbackStartsAt,
                LookbackEndsAt = (DateTime)summaryOutput.LookbackEndsAt,
                Value = new List<PackageStatistic>()
            };

            foreach (var summary in summaryOutput.ResultData)
            {
                result.Value.Add( new PackageStatistic() {
                   PackageId = summary.PackageId,
                   PackageName = summary.PackageName,
                   ProjectName = summary.ProjectName,
                   FolderName = summary.FolderName,
                   FirstExecutionStartedAt = summary.FirstExecutionStartedAt,
                   LastExecutionStartedAt = summary.LastExecutionStartedAt,
                   ExecutionCount = summary.ExecutionCount,
                   SuccessCount = summary.SuccessCount,
                   FailedCount = summary.FailedCount,
                   AverageDurationSeconds = summary.AverageDurationSeconds,
                   ShortestDurationSeconds = summary.ShortestDurationSeconds,
                   LongestDurationSeconds = summary.LongestDurationSeconds
                });
            }

            return result;
        }
    }
}
