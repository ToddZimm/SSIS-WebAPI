using SSIS.API.Models;
using SSIS.DataService.SSISDB.Models;

namespace SSIS.API.Mappers
{
    public static class FolderMapper
    {
        public static Folder Map (FoldersByIdResult foldersByIdResult, List<ProjectsResult>? projects)
        {
            Folder folder = new Folder()
            {
                FolderId = foldersByIdResult.FolderId,
                Name = foldersByIdResult.Name,
                Description = foldersByIdResult.Description,
                CreatedAt = foldersByIdResult.CreatedAt,
                CreatedBy = foldersByIdResult.CreatedBy,
                Projects = new List<Project>()
            };

            foreach (var prj in projects)
            {
                folder.Projects.Add(new Project()
                {
                    ProjectId = prj.ProjectId,
                    Name = prj.Name,
                    Description = prj.Description,
                    CreatedAt = prj.CreatedAt,
                    DeployedBy = prj.DeployedBy,
                    LastDeployedAt = prj.LastDeployedAt,
                    LastValidationAt = prj.LastValidationAt, 
                    ValidationStatus = prj.ValidationStatus,
                    FolderId = prj.FolderId,
                    FolderName = prj.FolderName
                });
            }

            return folder;
        }

        public static Folders MapSet (List<FoldersResult> foldersResults)
        {
            List<Folder> folders = new List<Folder>(foldersResults.Count);
            foreach (var f in foldersResults)
            {
                folders.Add(new Folder()
                {
                    FolderId = f.FolderId,
                    Name = f.Name,
                    Description = f.Description,
                    CreatedAt = f.CreatedAt,
                    CreatedBy = f.CreatedBy
                });
            }

            return new Folders() { Value = folders };
        }
    }
}
