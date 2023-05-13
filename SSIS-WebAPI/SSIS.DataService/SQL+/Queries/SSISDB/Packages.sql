--+SqlPlusRoutine
    --&SelectType=MultiRow
    --&Comment=Returns list of Packages in the SSIS Catalog
    --&Author=Todd Zimmerman
--+SqlPlusRoutine

--+Parameters

    DECLARE

    --+Default=0
    --+Comment=Parent Project ID to limit package results
    @ProjectId bigint = 0,

    --+Output
    @Count int

--+Parameters

SELECT p.package_id PackageId
  ,p.name Name
  ,p.description Description
  ,p.project_id ProjectId
  ,pr.name ProjectName
  ,f.name FolderName
  ,p.package_format_version PackageFormatVersion
  ,p.validation_status ValidationStatus
  ,p.last_validation_time LastValidationAt
  ,p.package_guid PackageGuid
  ,p.version_guid VersionGuid
  ,p.version_major VersionMajor
  ,p.version_minor VersionMinor
  ,p.version_build VersionBuild
  ,p.version_comments VersionComments
FROM catalog.packages p
LEFT JOIN catalog.projects pr on pr.project_id = p.project_id
LEFT JOIN catalog.folders f on f.folder_id = pr.folder_id
WHERE (@ProjectId = 0 OR p.project_id = @ProjectId);

SET @Count = @@ROWCOUNT;
