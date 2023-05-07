// --------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the SQL  Code Generation Utility.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//     Underlying Query: Folders
//     Last Modified On: 5/7/2023 1:40:20 PM
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
    /// Output object for Folders service.
    /// </summary>
    public partial class FoldersOutput
    {

        #region Output Parameters

        /// <summary>
        /// Maps to parameter @Count.
        /// </summary>
        public int? Count { set; get; }

	    #endregion Output Parameters

        #region Result Data

        /// <summary>
        /// List of FoldersResult.
        /// </summary>
        public List<FoldersResult>? ResultData { set; get; }

        #endregion Result Data
    }



    #region Result Set Objects

    /// <summary>
    /// Result object for Folders service.
    /// </summary>




    public partial class FoldersResult
	{
        /// <summary>
        /// Result set object for Folders.
        /// </summary>
        /// <param name="FolderId">Maps to table value column FolderId.</param>
        /// <param name="Name">Maps to table value column Name.</param>
        /// <param name="Description">Maps to table value column Description.</param>
        /// <param name="CreatedAt">Maps to table value column CreatedAt.</param>
        /// <param name="CreatedBy">Maps to table value column CreatedBy.</param>
        public FoldersResult(long FolderId, string Name, string? Description, DateTimeOffset CreatedAt, string CreatedBy)
        {
             this.FolderId = FolderId;
             this.Name = Name;
             this.Description = Description;
             this.CreatedAt = CreatedAt;
             this.CreatedBy = CreatedBy;
        }


        /// <summary>
        /// Maps to table value column FolderId.
        /// </summary>
        public long FolderId { set; get; }

        /// <summary>
        /// Maps to table value column Name.
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Maps to table value column Description.
        /// </summary>
        public string? Description { set; get; }

        /// <summary>
        /// Maps to table value column CreatedAt.
        /// </summary>
        public DateTimeOffset CreatedAt { set; get; }

        /// <summary>
        /// Maps to table value column CreatedBy.
        /// </summary>
        public string CreatedBy { set; get; }
    }


    #endregion Result Set Objects

}
