--+SqlPlusRoutine
    --&SelectType=MultiRow
    --&Comment=Returns list of projects in the SSIS Catalog
    --&Author=Todd Zimmerman
--+SqlPlusRoutine

--+Parameters

    DECLARE

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
LEFT JOIN catalog.folders f on f.folder_id = p.folder_id;

SET @Count = @@ROWCOUNT;

