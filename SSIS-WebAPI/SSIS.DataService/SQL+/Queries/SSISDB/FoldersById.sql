--+SqlPlusRoutine
    --&SelectType=SingleRow
    --&Comment=Returns Folder by ID in the SSIS Catalog
    --&Author=Todd Zimmerman
--+SqlPlusRoutine

--+Parameters

    DECLARE

    --+Required
    @Id bigint = 0,

    --+Output
    @ReturnValue int

--+Parameters

SELECT
   folder_id FolderId
  ,name Name
  ,description Description
  ,created_time CreatedAt
  ,created_by_name CreatedBy
FROM Catalog.Folders
WHERE folder_id = @Id;

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