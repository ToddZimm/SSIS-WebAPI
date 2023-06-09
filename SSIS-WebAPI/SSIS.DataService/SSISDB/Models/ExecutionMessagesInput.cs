// --------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the SQL PLUS Code Generation Utility.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//     Underlying Query: ExecutionMessages
//     Last Modified On: 5/13/2023 9:51:36 PM
//     Written By: Todd Zimmerman
//     Visit https://www.SQLPLUS.net for more information about the SQL PLUS build time ORM.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------
namespace SSIS.DataService.SSISDB.Models
{
    #region usings

    using SqlPlusBase;
    using System.ComponentModel.DataAnnotations;

    #endregion usings

    /// <summary>
    /// Input object for the ExecutionMessages service.
    /// </summary>
    public partial class ExecutionMessagesInput : ValidInput
    {
        #region Constructors

        /// <summary>
        /// Empty constructor for ExecutionMessagesInput.
        /// </summary>
        public ExecutionMessagesInput() { }

        /// <summary>
        /// Parameterized constructor for ExecutionMessagesInput.
        /// </summary>
        /// <param name="ExecutionId">Maps to parameter @ExecutionId.</param>
        /// <param name="BasicLogging">Include only basic logging messages. Excludes validation messages.</param>
        public ExecutionMessagesInput(long? ExecutionId, bool? BasicLogging)
        {
            this.ExecutionId = ExecutionId;
            this.BasicLogging = BasicLogging;
        }

        #endregion Constructors

        #region Fields

        private long? _ExecutionId;
        /// <summary>
        /// Maps to parameter @ExecutionId.
        /// </summary>
        [Required]
        public long? ExecutionId
        {
            get => _ExecutionId;
            set => _ExecutionId = value;
        }

        private bool? _BasicLogging = false;
        /// <summary>
        /// Include only basic logging messages. Excludes validation messages.
        /// </summary>
        public bool? BasicLogging
        {
            get => _BasicLogging;
            set => _BasicLogging = value;
        }

        #endregion

    }
}