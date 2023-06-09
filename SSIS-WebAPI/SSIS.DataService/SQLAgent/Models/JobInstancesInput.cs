// --------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the SQL PLUS Code Generation Utility.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//     Underlying Query: JobInstances
//     Last Modified On: 6/3/2023 6:53:01 PM
//     Written By: Todd Zimmerman
//     Visit https://www.SQLPLUS.net for more information about the SQL PLUS build time ORM.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------
namespace SSIS.DataService.SQLAgent.Models
{
    #region usings

    using SqlPlusBase;
    using System;
    using System.ComponentModel.DataAnnotations;

    #endregion usings

    /// <summary>
    /// Input object for the JobInstances service.
    /// </summary>
    public partial class JobInstancesInput : ValidInput
    {
        #region Constructors

        /// <summary>
        /// Empty constructor for JobInstancesInput.
        /// </summary>
        public JobInstancesInput() { }

        /// <summary>
        /// Parameterized constructor for JobInstancesInput.
        /// </summary>
        /// <param name="Page">Page number</param>
        /// <param name="PageSize">Number of records per page to return</param>
        /// <param name="JobId">Provide a Job ID to filter results</param>
        /// <param name="ParentInstanceId">Return all step instances related to a job outcome</param>
        /// <param name="OutcomeOnly">Return only job outcome without step details</param>
        /// <param name="RunStatusId">Provide a status value to filter results</param>
        /// <param name="StartTime">Start date and time to filter results</param>
        /// <param name="EndTime">End data and time to filter results</param>
        public JobInstancesInput(int? Page, int? PageSize, Guid? JobId, long? ParentInstanceId, bool? OutcomeOnly, int? RunStatusId, DateTime? StartTime, DateTime? EndTime)
        {
            this.Page = Page;
            this.PageSize = PageSize;
            this.JobId = JobId;
            this.ParentInstanceId = ParentInstanceId;
            this.OutcomeOnly = OutcomeOnly;
            this.RunStatusId = RunStatusId;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
        }

        #endregion Constructors

        #region Fields

        private int? _Page = 1;
        /// <summary>
        /// Page number
        /// </summary>
        public int? Page
        {
            get => _Page;
            set => _Page = value;
        }

        private int? _PageSize = 25;
        /// <summary>
        /// Number of records per page to return
        /// </summary>
        [Range(typeof(int), "10", "100")]
        public int? PageSize
        {
            get => _PageSize;
            set => _PageSize = value;
        }

        private Guid? _JobId;
        /// <summary>
        /// Provide a Job ID to filter results
        /// </summary>
        public Guid? JobId
        {
            get => _JobId;
            set => _JobId = value;
        }

        private long? _ParentInstanceId;
        /// <summary>
        /// Return all step instances related to a job outcome
        /// </summary>
        public long? ParentInstanceId
        {
            get => _ParentInstanceId;
            set => _ParentInstanceId = value;
        }

        private bool? _OutcomeOnly = true;
        /// <summary>
        /// Return only job outcome without step details
        /// </summary>
        public bool? OutcomeOnly
        {
            get => _OutcomeOnly;
            set => _OutcomeOnly = value;
        }

        private int? _RunStatusId;
        /// <summary>
        /// Provide a status value to filter results
        /// </summary>
        public int? RunStatusId
        {
            get => _RunStatusId;
            set => _RunStatusId = value;
        }

        private DateTime? _StartTime;
        /// <summary>
        /// Start date and time to filter results
        /// </summary>
        public DateTime? StartTime
        {
            get => _StartTime;
            set => _StartTime = value;
        }

        private DateTime? _EndTime;
        /// <summary>
        /// End data and time to filter results
        /// </summary>
        public DateTime? EndTime
        {
            get => _EndTime;
            set => _EndTime = value;
        }

        #endregion

    }
}