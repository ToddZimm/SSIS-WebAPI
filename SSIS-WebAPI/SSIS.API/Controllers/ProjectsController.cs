using Microsoft.AspNetCore.Mvc;
using SSIS.API.Mappers;
using SSIS.API.Models;
using SSIS.DataService.SSISDB;
using SSIS.DataService.SSISDB.Models;

namespace SSIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {

        private readonly SSIS.DataService.SSISDB.Service _dataService;

        public ProjectsController (SSIS.DataService.SSISDB.Service dataService)
        {
            _dataService = dataService;
        }

        // GET: api/<ProjectsController>
        [HttpGet]
        public ActionResult<Projects> Get()
        {
            var projects = _dataService.Projects(new ProjectsInput());
            if (projects.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(ProjectMapper.MapList(projects.ResultData));
            }
        }

        // GET api/<ProjectsController>/5
        [HttpGet("{id}")]
        public ActionResult<Project> Get(int id)
        {
            var project = _dataService.ProjectsById(new ProjectsByIdInput { Id = id });
            if (project.ReturnValue == ProjectsByIdOutput.Returns.NotFound)
            {
                return NotFound();
            }
            else
            {
                var packages = _dataService.Packages(new PackagesInput(project.ResultData.ProjectId)).ResultData;
                return Ok(ProjectMapper.Map(project.ResultData, packages));
            }
        }
    }
}
