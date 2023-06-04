using Microsoft.AspNetCore.Mvc;
using SSIS.API.Models;
using SSIS.API.Mappers;
using SSIS.DataService.SQLAgent.Models;

namespace SSIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobStepsController : ControllerBase
    {
        private readonly SSIS.DataService.SQLAgent.Service _dataService;

        public JobStepsController(SSIS.DataService.SQLAgent.Service dataService)
        {
            _dataService = dataService;
        }

        // GET: api/<JobStepsController>
        [HttpGet]
        public ActionResult<JobSteps> Get([FromQuery] Guid? JobId, [FromQuery] long? PackageId)
        {
            JobStepsInput input = new JobStepsInput() { JobId = JobId, PackageId = PackageId };
            var steps = _dataService.JobSteps(input);

            if (steps.Count == 0)
                return NoContent();
            else 
                return Ok(JobStepMapper.MapList(steps.ResultData));
        }
    }
}
