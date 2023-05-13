using SSIS.DataService.SSISDB.Models;

namespace SSIS.API.Models
{
    public class Folder
    {
        public long FolderId { set; get; }
        public string? Name { set; get; }
        public string? Description { set; get; }
        public DateTimeOffset CreatedAt { set; get; }
        public string? CreatedBy { set; get; }
        public List<Project>? Projects { set; get; } 
    }

    public class Folders
    {
        public List<Folder> Value { set; get; }
    }
}
