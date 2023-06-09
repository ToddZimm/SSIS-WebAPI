// --------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the SQL  Code Generation Utility.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//     Underlying Query: ExecutionStatus
//     Last Modified On: 7/3/2023 8:44:06 PM
//     Written By: Todd Zimmerman
//     Select Type: MultiRow
//     Visit https://www.SQLPLUS.net for more information about the SQL Plus build time ORM.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------
namespace SSIS.DataService.SSISDB.Models
{

    #region usings

    using System.Collections.Generic;

    #endregion usings

    /// <summary>
    /// Output object for ExecutionStatus service.
    /// </summary>
    public partial class ExecutionStatusOutput
    {

        #region Result Data

        /// <summary>
        /// List of ExecutionStatusResult.
        /// </summary>
        public List<ExecutionStatusResult> ResultData { set; get; }

        #endregion Result Data
    }



    #region Result Set Objects

    /// <summary>
    /// Result object for ExecutionStatus service.
    /// </summary>




    public partial class ExecutionStatusResult
	{
        /// <summary>
        /// Result set object for ExecutionStatus.
        /// </summary>
        /// <param name="Value">Maps to table value column Value.</param>
        /// <param name="Name">Maps to table value column Name.</param>
        /// <param name="Description">Maps to table value column Description.</param>
        public ExecutionStatusResult(int? Value, string Name, string Description)
        {
             this.Value = Value;
             this.Name = Name;
             this.Description = Description;
        }


        /// <summary>
        /// Maps to table value column Value.
        /// </summary>
        public int? Value { set; get; }

        /// <summary>
        /// Maps to table value column Name.
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Maps to table value column Description.
        /// </summary>
        public string Description { set; get; }
    }


    #endregion Result Set Objects

}
