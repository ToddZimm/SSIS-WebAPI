namespace SSIS.API.Models
{
    public class Package
    {
        public long PackageId { set; get; }
        public string? Name { set; get; }
        public string? Description { set; get; }
        public string? ProjectName { set; get; }
        public string? FolderName { set; get; }
        public int PackageFormatVersion { set; get; }
        public string? ValidationStatus { set; get; }
        public DateTimeOffset? LastValidationAt { set; get; }
        public Guid PackageGuid { set; get; }
        public Guid VersionGuid { set; get; }
        public int VersionMajor { set; get; }
        public int VersionMinor { set; get; }
        public int VersionBuild { set; get; }
        public string? VersionComments { set; get; }
    }

    public class Packages
    {
        public List<Package>? Value { set; get; }
    }
}
