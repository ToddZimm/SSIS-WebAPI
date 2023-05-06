// --------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the SQL  Code Generation Utility.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//     Underlying Query: Packages
//     Last Modified On: 5/3/2023 7:46:40 PM
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
    /// Output object for Packages service.
    /// </summary>
    public partial class PackagesOutput
    {

        #region Output Parameters

        /// <summary>
        /// Maps to parameter @Count.
        /// </summary>
        public int? Count { set; get; }

	    #endregion Output Parameters

        #region Result Data

        /// <summary>
        /// List of PackagesResult.
        /// </summary>
        public List<PackagesResult>? ResultData { set; get; }

        #endregion Result Data
    }



    #region Result Set Objects

    /// <summary>
    /// Result object for Packages service.
    /// </summary>




    public partial class PackagesResult
	{
        /// <summary>
        /// Result set object for Packages.
        /// </summary>
        /// <param name="PackageId">Maps to table value column PackageId.</param>
        /// <param name="PackageName">Maps to table value column PackageName.</param>
        /// <param name="Description">Maps to table value column Description.</param>
        /// <param name="ProjectName">Maps to table value column ProjectName.</param>
        /// <param name="FolderName">Maps to table value column FolderName.</param>
        /// <param name="PackageFormatVersion">Maps to table value column PackageFormatVersion.</param>
        /// <param name="ValidationStatus">Maps to table value column ValidationStatus.</param>
        /// <param name="LastValidationTime">Maps to table value column LastValidationTime.</param>
        /// <param name="PackageGuid">Maps to table value column PackageGuid.</param>
        /// <param name="VersionGuid">Maps to table value column VersionGuid.</param>
        /// <param name="VersionMajor">Maps to table value column VersionMajor.</param>
        /// <param name="VersionMinor">Maps to table value column VersionMinor.</param>
        /// <param name="VersionBuild">Maps to table value column VersionBuild.</param>
        /// <param name="VersionComments">Maps to table value column VersionComments.</param>
        public PackagesResult(long PackageId, string PackageName, string? Description, string? ProjectName, string? FolderName, int PackageFormatVersion, string ValidationStatus, DateTimeOffset? LastValidationTime, Guid PackageGuid, Guid VersionGuid, int VersionMajor, int VersionMinor, int VersionBuild, string? VersionComments)
        {
             this.PackageId = PackageId;
             this.PackageName = PackageName;
             this.Description = Description;
             this.ProjectName = ProjectName;
             this.FolderName = FolderName;
             this.PackageFormatVersion = PackageFormatVersion;
             this.ValidationStatus = ValidationStatus;
             this.LastValidationTime = LastValidationTime;
             this.PackageGuid = PackageGuid;
             this.VersionGuid = VersionGuid;
             this.VersionMajor = VersionMajor;
             this.VersionMinor = VersionMinor;
             this.VersionBuild = VersionBuild;
             this.VersionComments = VersionComments;
        }


        /// <summary>
        /// Maps to table value column PackageId.
        /// </summary>
        public long PackageId { set; get; }

        /// <summary>
        /// Maps to table value column PackageName.
        /// </summary>
        public string PackageName { set; get; }

        /// <summary>
        /// Maps to table value column Description.
        /// </summary>
        public string? Description { set; get; }

        /// <summary>
        /// Maps to table value column ProjectName.
        /// </summary>
        public string? ProjectName { set; get; }

        /// <summary>
        /// Maps to table value column FolderName.
        /// </summary>
        public string? FolderName { set; get; }

        /// <summary>
        /// Maps to table value column PackageFormatVersion.
        /// </summary>
        public int PackageFormatVersion { set; get; }

        /// <summary>
        /// Maps to table value column ValidationStatus.
        /// </summary>
        public string ValidationStatus { set; get; }

        /// <summary>
        /// Maps to table value column LastValidationTime.
        /// </summary>
        public DateTimeOffset? LastValidationTime { set; get; }

        /// <summary>
        /// Maps to table value column PackageGuid.
        /// </summary>
        public Guid PackageGuid { set; get; }

        /// <summary>
        /// Maps to table value column VersionGuid.
        /// </summary>
        public Guid VersionGuid { set; get; }

        /// <summary>
        /// Maps to table value column VersionMajor.
        /// </summary>
        public int VersionMajor { set; get; }

        /// <summary>
        /// Maps to table value column VersionMinor.
        /// </summary>
        public int VersionMinor { set; get; }

        /// <summary>
        /// Maps to table value column VersionBuild.
        /// </summary>
        public int VersionBuild { set; get; }

        /// <summary>
        /// Maps to table value column VersionComments.
        /// </summary>
        public string? VersionComments { set; get; }
    }


    #endregion Result Set Objects

}
