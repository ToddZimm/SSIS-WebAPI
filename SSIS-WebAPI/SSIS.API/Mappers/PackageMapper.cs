using SSIS.API.Models;
using SSIS.DataService.SSISDB.Models;

namespace SSIS.API.Mappers
{
    public static class PackageMapper
    {
        public static Package Map (PackagesByIdResult packagesByIdResult)
        {
            Package package = new()
            {
                PackageId = packagesByIdResult.PackageId,
                Name = packagesByIdResult.Name,
                Description = packagesByIdResult.Description,
                ProjectId = packagesByIdResult.ProjectId,
                ProjectName = packagesByIdResult.ProjectName,
                FolderName = packagesByIdResult.FolderName,
                PackageFormatVersion = packagesByIdResult.PackageFormatVersion,
                ValidationStatus = packagesByIdResult.ValidationStatus,
                LastValidationAt = packagesByIdResult.LastValidationAt,
                PackageGuid = packagesByIdResult.PackageGuid,
                VersionGuid = packagesByIdResult.VersionGuid,
                VersionMajor = packagesByIdResult.VersionMajor,
                VersionMinor = packagesByIdResult.VersionMinor,
                VersionBuild = packagesByIdResult.VersionBuild,
                VersionComments = packagesByIdResult.VersionComments,
                CreatedAt = packagesByIdResult.CreatedAt,
                LastDeployedAt = packagesByIdResult.LastDeployedAt
            };

            return package;
        }

        public static Packages MapList (List<PackagesResult> packagesResults)
        {
            Packages result = new() { Value = new List<Package>(packagesResults.Count) };
            foreach (var package in packagesResults)
            {
                result.Value.Add(new Package()
                {
                    PackageId = package.PackageId,
                    Name = package.Name,
                    Description = package.Description,
                    ProjectId = package.ProjectId,
                    ProjectName = package.ProjectName,
                    FolderName = package.FolderName,
                    PackageFormatVersion = package.PackageFormatVersion,
                    ValidationStatus = package.ValidationStatus,
                    LastValidationAt = package.LastValidationAt,
                    PackageGuid = package.PackageGuid,
                    VersionGuid = package.VersionGuid,
                    VersionMajor = package.VersionMajor,
                    VersionMinor = package.VersionMinor,
                    VersionBuild = package.VersionBuild,
                    VersionComments = package.VersionComments,
                    CreatedAt = package.CreatedAt,
                    LastDeployedAt = package.LastDeployedAt
                });
            }
            
            return result;
        }
    }
}
