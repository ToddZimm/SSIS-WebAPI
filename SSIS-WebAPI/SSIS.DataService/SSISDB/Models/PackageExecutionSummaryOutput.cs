// --------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the SQL  Code Generation Utility.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//     Underlying Query: PackageExecutionSummary
//     Last Modified On: 5/7/2023 3:14:36 PM
//     Written By: Todd Zimmerman
//     Select Type: MultiRow
//     Visit https://www.SQLPLUS.net for more information about the SQL Plus build time ORM.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------
namespace SSIS.DataService.SSISDB.Models
{
    #nullable enable


    #region usings

    using System;
    using System.Collections.Generic;

    #endregion usings

    /// <summary>
    /// Output object for PackageExecutionSummary service.
    /// </summary>
    public partial class PackageExecutionSummaryOutput
    {

        #region Output Parameters

        /// <summary>
        /// Maps to parameter @Count.
        /// </summary>
        public int? Count { set; get; }

	    #endregion Output Parameters

        #region Result Data

        /// <summary>
        /// List of PackageExecutionSummaryResult.
        /// </summary>
        public List<PackageExecutionSummaryResult>? ResultData { set; get; }

        #endregion Result Data
    }



    #region Result Set Objects

    /// <summary>
    /// Result object for PackageExecutionSummary service.
    /// </summary>




    public partial class PackageExecutionSummaryResult
	{
        /// <summary>
        /// Result set object for PackageExecutionSummary.
        /// </summary>
        /// <param name="package_id">Maps to table value column package_id.</param>
        /// <param name="package_name">Maps to table value column package_name.</param>
        /// <param name="project_name">Maps to table value column project_name.</param>
        /// <param name="folder_name">Maps to table value column folder_name.</param>
        /// <param name="FirstExecutionStartedAt">Maps to table value column FirstExecutionStartedAt.</param>
        /// <param name="LastExecutionStartedAt">Maps to table value column LastExecutionStartedAt.</param>
        /// <param name="ExecutionCount">Maps to table value column ExecutionCount.</param>
        /// <param name="SuccessCount">Maps to table value column SuccessCount.</param>
        /// <param name="FailedCount">Maps to table value column FailedCount.</param>
        /// <param name="AverageDurationSeconds">Maps to table value column AverageDurationSeconds.</param>
        /// <param name="AverageDurationDisplay">Maps to table value column AverageDurationDisplay.</param>
        public PackageExecutionSummaryResult(long package_id, string package_name, string project_name, string folder_name, DateTimeOffset? FirstExecutionStartedAt, DateTimeOffset? LastExecutionStartedAt, int? ExecutionCount, int? SuccessCount, int? FailedCount, int? AverageDurationSeconds, string? AverageDurationDisplay)
        {
             this.package_id = package_id;
             this.package_name = package_name;
             this.project_name = project_name;
             this.folder_name = folder_name;
             this.FirstExecutionStartedAt = FirstExecutionStartedAt;
             this.LastExecutionStartedAt = LastExecutionStartedAt;
             this.ExecutionCount = ExecutionCount;
             this.SuccessCount = SuccessCount;
             this.FailedCount = FailedCount;
             this.AverageDurationSeconds = AverageDurationSeconds;
             this.AverageDurationDisplay = AverageDurationDisplay;
        }


        /// <summary>
        /// Maps to table value column package_id.
        /// </summary>
        public long package_id { set; get; }

        /// <summary>
        /// Maps to table value column package_name.
        /// </summary>
        public string package_name { set; get; }

        /// <summary>
        /// Maps to table value column project_name.
        /// </summary>
        public string project_name { set; get; }

        /// <summary>
        /// Maps to table value column folder_name.
        /// </summary>
        public string folder_name { set; get; }

        /// <summary>
        /// Maps to table value column FirstExecutionStartedAt.
        /// </summary>
        public DateTimeOffset? FirstExecutionStartedAt { set; get; }

        /// <summary>
        /// Maps to table value column LastExecutionStartedAt.
        /// </summary>
        public DateTimeOffset? LastExecutionStartedAt { set; get; }

        /// <summary>
        /// Maps to table value column ExecutionCount.
        /// </summary>
        public int? ExecutionCount { set; get; }

        /// <summary>
        /// Maps to table value column SuccessCount.
        /// </summary>
        public int? SuccessCount { set; get; }

        /// <summary>
        /// Maps to table value column FailedCount.
        /// </summary>
        public int? FailedCount { set; get; }

        /// <summary>
        /// Maps to table value column AverageDurationSeconds.
        /// </summary>
        public int? AverageDurationSeconds { set; get; }

        /// <summary>
        /// Maps to table value column AverageDurationDisplay.
        /// </summary>
        public string? AverageDurationDisplay { set; get; }
    }


    #endregion Result Set Objects

}
