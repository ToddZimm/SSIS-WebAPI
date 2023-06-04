using Microsoft.AspNetCore.Mvc;
using SSIS.API.Mappers;
using SSIS.API.Models;
using SSIS.DataService.SQLAgent;

namespace SSIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly SSIS.DataService.SQLAgent.Service _dataService;

        public JobsController(SSIS.DataService.SQLAgent.Service dataService) 
        { 
            _dataService = dataService; 
        }

        // GET: api/<JobsController>
        [HttpGet]
        public ActionResult<Jobs> Get()
        {
            var jobs = _dataService.Jobs();
            if (jobs.Count == 0)
                return NoContent();
            else 
                return Ok(JobMapper.MapList(jobs.ResultData));
        }

        // GET api/<JobsController>/5
        [HttpGet("{id}")]
        public ActionResult<Job> Get(Guid id)
        {
            var job = _dataService.JobsById(new(id));
            if (job.ReturnValue == DataService.SQLAgent.Models.JobsByIdOutput.Returns.NotFound)
                return NotFound();
            else
            {
                var steps = _dataService.JobSteps(new(id, null)).ResultData;
                var scheds = _dataService.JobSchedules(new(id)).ResultData;
                return Ok(JobMapper.Map(job.ResultData, steps, scheds));
            }
                
        }
    }
}
