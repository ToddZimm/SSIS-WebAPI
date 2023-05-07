// --------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the SQL  Code Generation Utility.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//     Underlying Query: Executions
//     Last Modified On: 5/7/2023 8:34:17 AM
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
    /// Output object for Executions service.
    /// </summary>
    public partial class ExecutionsOutput
    {

        #region Output Parameters

        /// <summary>
        /// Maps to parameter @Count.
        /// </summary>
        public int? Count { set; get; }

	    #endregion Output Parameters

        #region Result Data

        /// <summary>
        /// List of ExecutionsResult.
        /// </summary>
        public List<ExecutionsResult>? ResultData { set; get; }

        #endregion Result Data
    }



    #region Result Set Objects

    /// <summary>
    /// Result object for Executions service.
    /// </summary>




    public partial class ExecutionsResult
	{
        /// <summary>
        /// Result set object for Executions.
        /// </summary>
        /// <param name="ExecutionId">Maps to table value column ExecutionId.</param>
        /// <param name="PackageId">Maps to table value column PackageId.</param>
        /// <param name="FolderName">Maps to table value column FolderName.</param>
        /// <param name="ProjectName">Maps to table value column ProjectName.</param>
        /// <param name="PackageName">Maps to table value column PackageName.</param>
        /// <param name="Status">Maps to table value column Status.</param>
        /// <param name="StatusName">Maps to table value column StatusName.</param>
        /// <param name="FirstErrorMessage">Maps to table value column FirstErrorMessage.</param>
        /// <param name="CreatedTime">Maps to table value column CreatedTime.</param>
        /// <param name="StartTime">Maps to table value column StartTime.</param>
        /// <param name="EndTime">Maps to table value column EndTime.</param>
        /// <param name="EnvironmentFolder">Maps to table value column EnvironmentFolder.</param>
        /// <param name="EnvironmentName">Maps to table value column EnvironmentName.</param>
        /// <param name="Caller">Maps to table value column Caller.</param>
        /// <param name="ExecutedAs">Maps to table value column ExecutedAs.</param>
        /// <param name="StoppedBy">Maps to table value column StoppedBy.</param>
        /// <param name="Use32BitRuntime">Maps to table value column Use32BitRuntime.</param>
        public ExecutionsResult(long ExecutionId, long PackageId, string FolderName, string ProjectName, string PackageName, int Status, string? StatusName, string? FirstErrorMessage, DateTimeOffset? CreatedTime, DateTimeOffset? StartTime, DateTimeOffset? EndTime, string? EnvironmentFolder, string? EnvironmentName, string Caller, string ExecutedAs, string? StoppedBy, bool Use32BitRuntime)
        {
             this.ExecutionId = ExecutionId;
             this.PackageId = PackageId;
             this.FolderName = FolderName;
             this.ProjectName = ProjectName;
             this.PackageName = PackageName;
             this.Status = Status;
             this.StatusName = StatusName;
             this.FirstErrorMessage = FirstErrorMessage;
             this.CreatedTime = CreatedTime;
             this.StartTime = StartTime;
             this.EndTime = EndTime;
             this.EnvironmentFolder = EnvironmentFolder;
             this.EnvironmentName = EnvironmentName;
             this.Caller = Caller;
             this.ExecutedAs = ExecutedAs;
             this.StoppedBy = StoppedBy;
             this.Use32BitRuntime = Use32BitRuntime;
        }


        /// <summary>
        /// Maps to table value column ExecutionId.
        /// </summary>
        public long ExecutionId { set; get; }

        /// <summary>
        /// Maps to table value column PackageId.
        /// </summary>
        public long PackageId { set; get; }

        /// <summary>
        /// Maps to table value column FolderName.
        /// </summary>
        public string FolderName { set; get; }

        /// <summary>
        /// Maps to table value column ProjectName.
        /// </summary>
        public string ProjectName { set; get; }

        /// <summary>
        /// Maps to table value column PackageName.
        /// </summary>
        public string PackageName { set; get; }

        /// <summary>
        /// Maps to table value column Status.
        /// </summary>
        public int Status { set; get; }

        /// <summary>
        /// Maps to table value column StatusName.
        /// </summary>
        public string? StatusName { set; get; }

        /// <summary>
        /// Maps to table value column FirstErrorMessage.
        /// </summary>
        public string? FirstErrorMessage { set; get; }

        /// <summary>
        /// Maps to table value column CreatedTime.
        /// </summary>
        public DateTimeOffset? CreatedTime { set; get; }

        /// <summary>
        /// Maps to table value column StartTime.
        /// </summary>
        public DateTimeOffset? StartTime { set; get; }

        /// <summary>
        /// Maps to table value column EndTime.
        /// </summary>
        public DateTimeOffset? EndTime { set; get; }

        /// <summary>
        /// Maps to table value column EnvironmentFolder.
        /// </summary>
        public string? EnvironmentFolder { set; get; }

        /// <summary>
        /// Maps to table value column EnvironmentName.
        /// </summary>
        public string? EnvironmentName { set; get; }

        /// <summary>
        /// Maps to table value column Caller.
        /// </summary>
        public string Caller { set; get; }

        /// <summary>
        /// Maps to table value column ExecutedAs.
        /// </summary>
        public string ExecutedAs { set; get; }

        /// <summary>
        /// Maps to table value column StoppedBy.
        /// </summary>
        public string? StoppedBy { set; get; }

        /// <summary>
        /// Maps to table value column Use32BitRuntime.
        /// </summary>
        public bool Use32BitRuntime { set; get; }
    }


    #endregion Result Set Objects

}