--+SqlPlusRoutine
    --&SelectType=SingleRow
    --&Comment=Returns Project by ID in the SSIS Catalog
    --&Author=Todd Zimmerman
--+SqlPlusRoutine

--+Parameters

    DECLARE

    --+Required
    @Id bigint = 0,

    --+Output
    @ReturnValue int

--+Parameters

SELECT p.package_id PackageId
  ,p.name Name
  ,p.description Description
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
WHERE p.package_id = @Id;

IF @@ROWCOUNT = 0
BEGIN
    --+Return=NotFound
    SET @ReturnValue=0;
END;
ELSE
BEGIN
    --+ReturnValue=Ok
    SET @ReturnValue = 1;
END;
