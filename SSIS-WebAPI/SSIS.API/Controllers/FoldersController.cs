using Microsoft.AspNetCore.Mvc;
using SSIS.API.Mappers;
using SSIS.API.Models;
using SSIS.DataService.SSISDB;
using SSIS.DataService.SSISDB.Models;

namespace SSIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoldersController : ControllerBase
    {
        private readonly SSIS.DataService.SSISDB.Service _dataService;

        public FoldersController (SSIS.DataService.SSISDB.Service dataService)
        {
            _dataService = dataService;
        }

        // GET: api/<FoldersController>
        [HttpGet]
        public ActionResult<Folders> Get()
        {
            var folders = _dataService.Folders();
            if (folders.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(FolderMapper.MapList(folders.ResultData));
            }
        }

        // GET api/<FoldersController>/5
        [HttpGet("{id}")]
        public ActionResult<Folder> Get(int id)
        {
            FoldersByIdOutput folderOutput = _dataService.FoldersById(new FoldersByIdInput(id));
            
            if (folderOutput.ReturnValue == FoldersByIdOutput.Returns.NotFound)
            {
                return NotFound();
            }
            else
            {
                List<ProjectsResult> projects = _dataService.Projects(new ProjectsInput(folderOutput.ResultData.FolderId)).ResultData;
                return Ok(FolderMapper.Map(folderOutput.ResultData, projects));
            }
        }
    }
}
