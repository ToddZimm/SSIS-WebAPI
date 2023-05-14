using SSIS.API.Models;
using SSIS.DataService.SSISDB.Models;

namespace SSIS.API.Mappers
{
    public static class ProjectMapper
    {
        public static Project Map(ProjectsByIdResult projectsByIdResult, List<PackagesResult> packagesResults)
        {
            Project project = new()
            {
                ProjectId = projectsByIdResult.ProjectId,   
                Name = projectsByIdResult.Name, 
                Description = projectsByIdResult.Description,
                FolderId = projectsByIdResult.FolderId,
                FolderName = projectsByIdResult.FolderName,
                DeployedBy = projectsByIdResult.DeployedBy,
                LastDeployedAt = projectsByIdResult.LastDeployedAt,
                CreatedAt = projectsByIdResult.CreatedAt,
                LastValidationAt = projectsByIdResult.LastValidationAt,
                ValidationStatus = projectsByIdResult.ValidationStatus,
                Packages = new List<Package>()
            };

            foreach (var p in packagesResults)
            {
                project.Packages.Add(new Package()
                {
                    PackageId = p.PackageId,
                    Name = p.Name,
                    Description = p.Description,
                    ProjectName = p.ProjectName,
                    FolderName = p.FolderName,
                    PackageFormatVersion = p.PackageFormatVersion,
                    ValidationStatus = p.ValidationStatus,
                    LastValidationAt = p.LastValidationAt,
                    PackageGuid = p.PackageGuid,
                    VersionGuid = p.VersionGuid,
                    VersionMajor = p.VersionMajor,
                    VersionMinor = p.VersionMinor,
                    VersionBuild = p.VersionBuild, 
                    VersionComments = p.VersionComments
                });
            }

            return project;
        }

        public static Projects MapList (List<ProjectsResult> projectsResults)
        {
            List<Project> projects = new();
            foreach (var projectResult in projectsResults)
            {
                projects.Add(new Project()
                {
                    ProjectId = projectResult.ProjectId,
                    Name = projectResult.Name,
                    Description = projectResult.Description,
                    FolderId = projectResult.FolderId,
                    FolderName = projectResult.FolderName,
                    DeployedBy = projectResult.DeployedBy,
                    LastDeployedAt = projectResult.LastDeployedAt,
                    CreatedAt = projectResult.CreatedAt,
                    LastValidationAt = projectResult.LastValidationAt,
                    ValidationStatus = projectResult.ValidationStatus
                });
            }

            return new Projects() { Value = projects };
        }
    }
}
