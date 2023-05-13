--+SqlPlusRoutine
    --&SelectType=MultiRow
    --&Comment=Returns list of projects in the SSIS Catalog
    --&Author=Todd Zimmerman
--+SqlPlusRoutine

--+Parameters

    DECLARE

    --+Default=0
    --+Comment=Parent Folder ID to limit the Project results
    @FolderId bigint = 0,

    --+Output
    @Count int

--+Parameters

SELECT p.project_id ProjectId
  ,p.name Name
  ,p.description Description
  ,f.folder_id FolderId
  ,f.name FolderName
  ,p.deployed_by_name DeployedBy
  ,p.last_deployed_time LastDeployedAt
  ,p.created_time CreatedAt
  ,p.last_validation_time LastValidationAt
  ,p.validation_status ValidationStatus
FROM catalog.projects p
LEFT JOIN catalog.folders f on f.folder_id = p.folder_id
WHERE (@FolderId = 0 OR p.folder_id = @FolderId);

SET @Count = @@ROWCOUNT;

