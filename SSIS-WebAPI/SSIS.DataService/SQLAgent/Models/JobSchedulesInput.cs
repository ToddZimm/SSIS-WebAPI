// --------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the SQL PLUS Code Generation Utility.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//     Underlying Query: JobSchedules
//     Last Modified On: 5/28/2023 8:07:03 PM
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
    /// Input object for the JobSchedules service.
    /// </summary>
    public partial class JobSchedulesInput : ValidInput
    {
        #region Constructors

        /// <summary>
        /// Empty constructor for JobSchedulesInput.
        /// </summary>
        public JobSchedulesInput() { }

        /// <summary>
        /// Parameterized constructor for JobSchedulesInput.
        /// </summary>
        /// <param name="JobId">Maps to parameter @JobId.</param>
        public JobSchedulesInput(Guid? JobId)
        {
            this.JobId = JobId;
        }

        #endregion Constructors

        #region Fields

        private Guid? _JobId;
        /// <summary>
        /// Maps to parameter @JobId.
        /// </summary>
        [Required]
        public Guid? JobId
        {
            get => _JobId;
            set => _JobId = value;
        }

        #endregion

    }
}