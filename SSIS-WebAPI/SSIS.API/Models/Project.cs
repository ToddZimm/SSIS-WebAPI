namespace SSIS.API.Models
{
    public class Project
    {
        public long ProjectId { set; get; }
        public string? Name { set; get; }
        public string? Description { set; get; }
        public long? FolderId { set; get; }
        public string? FolderName { set; get; }
        public string? DeployedBy { set; get; }
        public DateTimeOffset LastDeployedAt { set; get; }
        public DateTimeOffset CreatedAt { set; get; }
        public DateTimeOffset? LastValidationAt { set; get; }
        public string? ValidationStatus { set; get; }
        public List<Package>? Packages { set; get; }
    }

    public class Projects
    {
        public List<Package> Value { set; get;}
    }
}
