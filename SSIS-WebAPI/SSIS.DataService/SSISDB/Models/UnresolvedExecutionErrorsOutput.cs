// --------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the SQL  Code Generation Utility.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//     Underlying Query: UnresolvedExecutionErrors
//     Last Modified On: 5/15/2023 10:24:53 PM
//     Written By: Todd Zimmerman
//     Select Type: MultiRow
//     Visit https://www.SQLPLUS.net for more information about the SQL Plus build time ORM.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------
namespace SSIS.DataService.SSISDB.Models
{

    #region usings

    using System;
    using System.Collections.Generic;

    #endregion usings

    /// <summary>
    /// Output object for UnresolvedExecutionErrors service.
    /// </summary>
    public partial class UnresolvedExecutionErrorsOutput
    {

        #region Output Parameters

        /// <summary>
        /// Maps to parameter @Count.
        /// </summary>
        public int? Count { set; get; }

	    #endregion Output Parameters

        #region Result Data

        /// <summary>
        /// List of UnresolvedExecutionErrorsResult.
        /// </summary>
        public List<UnresolvedExecutionErrorsResult> ResultData { set; get; }

        #endregion Result Data
    }



    #region Result Set Objects

    /// <summary>
    /// Result object for UnresolvedExecutionErrors service.
    /// </summary>




    public partial class UnresolvedExecutionErrorsResult
	{
        /// <summary>
        /// Result set object for UnresolvedExecutionErrors.
        /// </summary>
        /// <param name="ExecutionId">Maps to table value column ExecutionId.</param>
        /// <param name="PackageId">Maps to table value column PackageId.</param>
        /// <param name="FolderName">Maps to table value column FolderName.</param>
        /// <param name="ProjectName">Maps to table value column ProjectName.</param>
        /// <param name="PackageName">Maps to table value column PackageName.</param>
        /// <param name="StatusId">Maps to table value column StatusId.</param>
        /// <param name="StatusName">Maps to table value column StatusName.</param>
        /// <param name="FirstErrorMessage">Maps to table value column FirstErrorMessage.</param>
        /// <param name="CreatedAt">Maps to table value column CreatedAt.</param>
        /// <param name="StartedAt">Maps to table value column StartedAt.</param>
        /// <param name="EndedAt">Maps to table value column EndedAt.</param>
        /// <param name="EnvironmentFolder">Maps to table value column EnvironmentFolder.</param>
        /// <param name="EnvironmentName">Maps to table value column EnvironmentName.</param>
        /// <param name="CalledBy">Maps to table value column CalledBy.</param>
        /// <param name="ExecutedAs">Maps to table value column ExecutedAs.</param>
        /// <param name="StoppedBy">Maps to table value column StoppedBy.</param>
        /// <param name="Use32BitRuntime">Maps to table value column Use32BitRuntime.</param>
        /// <param name="DurationSeconds">Maps to table value column DurationSeconds.</param>
        /// <param name="DurationDisplay">Maps to table value column DurationDisplay.</param>
        /// <param name="ServerName">Maps to table value column ServerName.</param>
        public UnresolvedExecutionErrorsResult(long ExecutionId, long PackageId, string FolderName, string ProjectName, string PackageName, int StatusId, string StatusName, string FirstErrorMessage, DateTimeOffset? CreatedAt, DateTimeOffset? StartedAt, DateTimeOffset? EndedAt, string EnvironmentFolder, string EnvironmentName, string CalledBy, string ExecutedAs, string StoppedBy, bool Use32BitRuntime, int? DurationSeconds, string DurationDisplay, string ServerName)
        {
             this.ExecutionId = ExecutionId;
             this.PackageId = PackageId;
             this.FolderName = FolderName;
             this.ProjectName = ProjectName;
             this.PackageName = PackageName;
             this.StatusId = StatusId;
             this.StatusName = StatusName;
             this.FirstErrorMessage = FirstErrorMessage;
             this.CreatedAt = CreatedAt;
             this.StartedAt = StartedAt;
             this.EndedAt = EndedAt;
             this.EnvironmentFolder = EnvironmentFolder;
             this.EnvironmentName = EnvironmentName;
             this.CalledBy = CalledBy;
             this.ExecutedAs = ExecutedAs;
             this.StoppedBy = StoppedBy;
             this.Use32BitRuntime = Use32BitRuntime;
             this.DurationSeconds = DurationSeconds;
             this.DurationDisplay = DurationDisplay;
             this.ServerName = ServerName;
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
        /// Maps to table value column StatusId.
        /// </summary>
        public int StatusId { set; get; }

        /// <summary>
        /// Maps to table value column StatusName.
        /// </summary>
        public string StatusName { set; get; }

        /// <summary>
        /// Maps to table value column FirstErrorMessage.
        /// </summary>
        public string FirstErrorMessage { set; get; }

        /// <summary>
        /// Maps to table value column CreatedAt.
        /// </summary>
        public DateTimeOffset? CreatedAt { set; get; }

        /// <summary>
        /// Maps to table value column StartedAt.
        /// </summary>
        public DateTimeOffset? StartedAt { set; get; }

        /// <summary>
        /// Maps to table value column EndedAt.
        /// </summary>
        public DateTimeOffset? EndedAt { set; get; }

        /// <summary>
        /// Maps to table value column EnvironmentFolder.
        /// </summary>
        public string EnvironmentFolder { set; get; }

        /// <summary>
        /// Maps to table value column EnvironmentName.
        /// </summary>
        public string EnvironmentName { set; get; }

        /// <summary>
        /// Maps to table value column CalledBy.
        /// </summary>
        public string CalledBy { set; get; }

        /// <summary>
        /// Maps to table value column ExecutedAs.
        /// </summary>
        public string ExecutedAs { set; get; }

        /// <summary>
        /// Maps to table value column StoppedBy.
        /// </summary>
        public string StoppedBy { set; get; }

        /// <summary>
        /// Maps to table value column Use32BitRuntime.
        /// </summary>
        public bool Use32BitRuntime { set; get; }

        /// <summary>
        /// Maps to table value column DurationSeconds.
        /// </summary>
        public int? DurationSeconds { set; get; }

        /// <summary>
        /// Maps to table value column DurationDisplay.
        /// </summary>
        public string DurationDisplay { set; get; }

        /// <summary>
        /// Maps to table value column ServerName.
        /// </summary>
        public string ServerName { set; get; }
    }


    #endregion Result Set Objects

}
