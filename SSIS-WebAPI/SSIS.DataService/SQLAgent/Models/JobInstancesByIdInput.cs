// --------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the SQL PLUS Code Generation Utility.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//     Underlying Query: JobInstancesById
//     Last Modified On: 6/3/2023 6:50:15 PM
//     Written By: Todd Zimmerman
//     Visit https://www.SQLPLUS.net for more information about the SQL PLUS build time ORM.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------
namespace SSIS.DataService.SQLAgent.Models
{
    #region usings

    using SqlPlusBase;
    using System.ComponentModel.DataAnnotations;

    #endregion usings

    /// <summary>
    /// Input object for the JobInstancesById service.
    /// </summary>
    public partial class JobInstancesByIdInput : ValidInput
    {
        #region Constructors

        /// <summary>
        /// Empty constructor for JobInstancesByIdInput.
        /// </summary>
        public JobInstancesByIdInput() { }

        /// <summary>
        /// Parameterized constructor for JobInstancesByIdInput.
        /// </summary>
        /// <param name="Id">Maps to parameter @Id.</param>
        public JobInstancesByIdInput(long? Id)
        {
            this.Id = Id;
        }

        #endregion Constructors

        #region Fields

        private long? _Id;
        /// <summary>
        /// Maps to parameter @Id.
        /// </summary>
        [Required]
        public long? Id
        {
            get => _Id;
            set => _Id = value;
        }

        #endregion

    }
}