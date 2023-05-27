// --------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the SQL  Code Generation Utility.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//     Underlying Query: JobInstances
//     Last Modified On: 5/27/2023 9:13:29 AM
//     Written By: Todd Zimmerman
//     Select Type: MultiRow
//     Visit https://www.SQLPLUS.net for more information about the SQL Plus build time ORM.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------
namespace SSIS.DataService.SQLAgent.Models
{

    #region usings

    using System;
    using System.Collections.Generic;

    #endregion usings

    /// <summary>
    /// Output object for JobInstances service.
    /// </summary>
    public partial class JobInstancesOutput
    {

        #region Output Parameters

        /// <summary>
        /// Page number
        /// </summary>
        public int? Page { set; get; }
        /// <summary>
        /// Number of records per page to return
        /// </summary>
        public int? PageSize { set; get; }
        /// <summary>
        /// Maps to parameter @Count.
        /// </summary>
        public int? Count { set; get; }

	    #endregion Output Parameters

        #region Result Data

        /// <summary>
        /// List of JobInstancesResult.
        /// </summary>
        public List<JobInstancesResult> ResultData { set; get; }

        #endregion Result Data
    }



    #region Result Set Objects

    /// <summary>
    /// Result object for JobInstances service.
    /// </summary>




    public partial class JobInstancesResult
	{
        /// <summary>
        /// Result set object for JobInstances.
        /// </summary>
        /// <param name="InstanceId">Maps to table value column InstanceId.</param>
        /// <param name="ParentInstanceId">Maps to table value column ParentInstanceId.</param>
        /// <param name="JobId">Maps to table value column JobId.</param>
        /// <param name="JobName">Maps to table value column JobName.</param>
        /// <param name="StepSequenceId">Maps to table value column StepSequenceId.</param>
        /// <param name="StepName">Maps to table value column StepName.</param>
        /// <param name="subsystem">Maps to table value column subsystem.</param>
        /// <param name="command">Maps to table value column command.</param>
        /// <param name="Message">Maps to table value column Message.</param>
        /// <param name="StartedAt">Maps to table value column StartedAt.</param>
        /// <param name="EndedAt">Maps to table value column EndedAt.</param>
        /// <param name="DurationSeconds">Maps to table value column DurationSeconds.</param>
        /// <param name="DurationDisplay">Maps to table value column DurationDisplay.</param>
        /// <param name="RunStatus">Maps to table value column RunStatus.</param>
        /// <param name="RetriesAttempted">Maps to table value column RetriesAttempted.</param>
        /// <param name="SqlMessageId">Maps to table value column SqlMessageId.</param>
        /// <param name="SqlSeverity">Maps to table value column SqlSeverity.</param>
        /// <param name="Server">Maps to table value column Server.</param>
        /// <param name="PackagePath">Maps to table value column PackagePath.</param>
        /// <param name="ExecutionId">Maps to table value column ExecutionId.</param>
        /// <param name="ExecutionStatus">Maps to table value column ExecutionStatus.</param>
        /// <param name="OperatorEmailed">Maps to table value column OperatorEmailed.</param>
        /// <param name="OperatorNetSent">Maps to table value column OperatorNetSent.</param>
        /// <param name="OperatorPaged">Maps to table value column OperatorPaged.</param>
        public JobInstancesResult(int InstanceId, int ParentInstanceId, Guid JobId, string JobName, int StepSequenceId, string StepName, string subsystem, string command, string Message, DateTime? StartedAt, DateTime? EndedAt, int? DurationSeconds, string DurationDisplay, string RunStatus, int RetriesAttempted, int SqlMessageId, int SqlSeverity, string Server, string PackagePath, long? ExecutionId, string ExecutionStatus, string OperatorEmailed, string OperatorNetSent, string OperatorPaged)
        {
             this.InstanceId = InstanceId;
             this.ParentInstanceId = ParentInstanceId;
             this.JobId = JobId;
             this.JobName = JobName;
             this.StepSequenceId = StepSequenceId;
             this.StepName = StepName;
             this.subsystem = subsystem;
             this.command = command;
             this.Message = Message;
             this.StartedAt = StartedAt;
             this.EndedAt = EndedAt;
             this.DurationSeconds = DurationSeconds;
             this.DurationDisplay = DurationDisplay;
             this.RunStatus = RunStatus;
             this.RetriesAttempted = RetriesAttempted;
             this.SqlMessageId = SqlMessageId;
             this.SqlSeverity = SqlSeverity;
             this.Server = Server;
             this.PackagePath = PackagePath;
             this.ExecutionId = ExecutionId;
             this.ExecutionStatus = ExecutionStatus;
             this.OperatorEmailed = OperatorEmailed;
             this.OperatorNetSent = OperatorNetSent;
             this.OperatorPaged = OperatorPaged;
        }


        /// <summary>
        /// Maps to table value column InstanceId.
        /// </summary>
        public int InstanceId { set; get; }

        /// <summary>
        /// Maps to table value column ParentInstanceId.
        /// </summary>
        public int ParentInstanceId { set; get; }

        /// <summary>
        /// Maps to table value column JobId.
        /// </summary>
        public Guid JobId { set; get; }

        /// <summary>
        /// Maps to table value column JobName.
        /// </summary>
        public string JobName { set; get; }

        /// <summary>
        /// Maps to table value column StepSequenceId.
        /// </summary>
        public int StepSequenceId { set; get; }

        /// <summary>
        /// Maps to table value column StepName.
        /// </summary>
        public string StepName { set; get; }

        /// <summary>
        /// Maps to table value column subsystem.
        /// </summary>
        public string subsystem { set; get; }

        /// <summary>
        /// Maps to table value column command.
        /// </summary>
        public string command { set; get; }

        /// <summary>
        /// Maps to table value column Message.
        /// </summary>
        public string Message { set; get; }

        /// <summary>
        /// Maps to table value column StartedAt.
        /// </summary>
        public DateTime? StartedAt { set; get; }

        /// <summary>
        /// Maps to table value column EndedAt.
        /// </summary>
        public DateTime? EndedAt { set; get; }

        /// <summary>
        /// Maps to table value column DurationSeconds.
        /// </summary>
        public int? DurationSeconds { set; get; }

        /// <summary>
        /// Maps to table value column DurationDisplay.
        /// </summary>
        public string DurationDisplay { set; get; }

        /// <summary>
        /// Maps to table value column RunStatus.
        /// </summary>
        public string RunStatus { set; get; }

        /// <summary>
        /// Maps to table value column RetriesAttempted.
        /// </summary>
        public int RetriesAttempted { set; get; }

        /// <summary>
        /// Maps to table value column SqlMessageId.
        /// </summary>
        public int SqlMessageId { set; get; }

        /// <summary>
        /// Maps to table value column SqlSeverity.
        /// </summary>
        public int SqlSeverity { set; get; }

        /// <summary>
        /// Maps to table value column Server.
        /// </summary>
        public string Server { set; get; }

        /// <summary>
        /// Maps to table value column PackagePath.
        /// </summary>
        public string PackagePath { set; get; }

        /// <summary>
        /// Maps to table value column ExecutionId.
        /// </summary>
        public long? ExecutionId { set; get; }

        /// <summary>
        /// Maps to table value column ExecutionStatus.
        /// </summary>
        public string ExecutionStatus { set; get; }

        /// <summary>
        /// Maps to table value column OperatorEmailed.
        /// </summary>
        public string OperatorEmailed { set; get; }

        /// <summary>
        /// Maps to table value column OperatorNetSent.
        /// </summary>
        public string OperatorNetSent { set; get; }

        /// <summary>
        /// Maps to table value column OperatorPaged.
        /// </summary>
        public string OperatorPaged { set; get; }
    }


    #endregion Result Set Objects

}
