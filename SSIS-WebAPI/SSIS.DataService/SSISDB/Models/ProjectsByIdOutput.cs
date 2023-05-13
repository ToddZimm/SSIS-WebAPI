// --------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the SQL  Code Generation Utility.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//     Underlying Query: ProjectsById
//     Last Modified On: 5/13/2023 3:58:03 PM
//     Written By: Todd Zimmerman
//     Select Type: SingleRow
//     Visit https://www.SQLPLUS.net for more information about the SQL Plus build time ORM.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------
namespace SSIS.DataService.SSISDB.Models
{

    #region usings

    using System;

    #endregion usings

    /// <summary>
    /// Output object for ProjectsById service.
    /// </summary>
    public partial class ProjectsByIdOutput
    {

        #region Return Value Enumerations

        /// <summary>
        /// Enumerated return values based on the ReturnTags in the procedure.
        /// </summary>
        public enum Returns
        {
            /// <summary>
            /// Enumerated value for NotFound
            /// </summary>
             NotFound = 0,
            /// <summary>
            /// Enumerated value for Ok
            /// </summary>
             Ok = 1
        }

        #endregion Return Value Enumerations

        #region Output Parameters

        /// <summary>
        /// Maps to parameter @ReturnValue.
        /// </summary>
        public Returns? ReturnValue { set; get; }

	    #endregion Output Parameters

        #region Result Data

        /// <summary>
        /// Single instance of ProjectsByIdResult.
        /// </summary>
        public ProjectsByIdResult ResultData { set; get; }

        #endregion Result Data
    }



    #region Result Set Objects

    /// <summary>
    /// Result object for ProjectsById service.
    /// </summary>




    public partial class ProjectsByIdResult
	{
        /// <summary>
        /// Result set object for ProjectsById.
        /// </summary>
        /// <param name="ProjectId">Maps to table value column ProjectId.</param>
        /// <param name="Name">Maps to table value column Name.</param>
        /// <param name="Description">Maps to table value column Description.</param>
        /// <param name="FolderId">Maps to table value column FolderId.</param>
        /// <param name="FolderName">Maps to table value column FolderName.</param>
        /// <param name="DeployedBy">Maps to table value column DeployedBy.</param>
        /// <param name="LastDeployedAt">Maps to table value column LastDeployedAt.</param>
        /// <param name="CreatedAt">Maps to table value column CreatedAt.</param>
        /// <param name="LastValidationAt">Maps to table value column LastValidationAt.</param>
        /// <param name="ValidationStatus">Maps to table value column ValidationStatus.</param>
        public ProjectsByIdResult(long ProjectId, string Name, string Description, long? FolderId, string FolderName, string DeployedBy, DateTimeOffset LastDeployedAt, DateTimeOffset CreatedAt, DateTimeOffset? LastValidationAt, string ValidationStatus)
        {
             this.ProjectId = ProjectId;
             this.Name = Name;
             this.Description = Description;
             this.FolderId = FolderId;
             this.FolderName = FolderName;
             this.DeployedBy = DeployedBy;
             this.LastDeployedAt = LastDeployedAt;
             this.CreatedAt = CreatedAt;
             this.LastValidationAt = LastValidationAt;
             this.ValidationStatus = ValidationStatus;
        }


        /// <summary>
        /// Maps to table value column ProjectId.
        /// </summary>
        public long ProjectId { set; get; }

        /// <summary>
        /// Maps to table value column Name.
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Maps to table value column Description.
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        /// Maps to table value column FolderId.
        /// </summary>
        public long? FolderId { set; get; }

        /// <summary>
        /// Maps to table value column FolderName.
        /// </summary>
        public string FolderName { set; get; }

        /// <summary>
        /// Maps to table value column DeployedBy.
        /// </summary>
        public string DeployedBy { set; get; }

        /// <summary>
        /// Maps to table value column LastDeployedAt.
        /// </summary>
        public DateTimeOffset LastDeployedAt { set; get; }

        /// <summary>
        /// Maps to table value column CreatedAt.
        /// </summary>
        public DateTimeOffset CreatedAt { set; get; }

        /// <summary>
        /// Maps to table value column LastValidationAt.
        /// </summary>
        public DateTimeOffset? LastValidationAt { set; get; }

        /// <summary>
        /// Maps to table value column ValidationStatus.
        /// </summary>
        public string ValidationStatus { set; get; }
    }


    #endregion Result Set Objects

}
