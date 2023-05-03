--+SqlPlusRoutine
    --&SelectType=MultiRow
    --&Comment=Returns list of folders in the SSIS Catalog
    --&Author=Todd Zimmerman
--+SqlPlusRoutine

--+Parameters

    DECLARE

    --+Output
    @Count int

--+Parameters

SELECT
   folder_id FolderId
  ,name FolderName
  ,description Description
  ,created_time CreatedTime
  ,created_by_name CreatedBy
FROM Catalog.Folders;

SET @Count = @@ROWCOUNT;
