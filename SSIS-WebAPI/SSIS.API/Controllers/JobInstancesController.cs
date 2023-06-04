using Microsoft.AspNetCore.Mvc;
using SSIS.API.Models;
using SSIS.API.Mappers;
using SSIS.DataService.SQLAgent.Models;

namespace SSIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobInstancesController : ControllerBase
    {
        private readonly SSIS.DataService.SQLAgent.Service _dataService;

        public JobInstancesController(SSIS.DataService.SQLAgent.Service dataService)
        {
            _dataService = dataService;
        }

        // GET: api/<JobInstancesController>
        [HttpGet]
        public ActionResult<JobInstances> Get([FromQuery] int? page,
            [FromQuery] int? pageSize, [FromQuery] Guid? jobId, [FromQuery] int? parentInstanceId,
            [FromQuery] bool? outcomeOnly, [FromQuery] int? runStatusId, [FromQuery] DateTime? startTime, [FromQuery] DateTime? endTime)
        {
            JobInstancesInput input = new() 
            { 
                Page = page,
                PageSize = pageSize,
                JobId = jobId,
                ParentInstanceId = parentInstanceId,
                OutcomeOnly = outcomeOnly,
                RunStatusId = runStatusId,
                StartTime = startTime,
                EndTime = endTime
            };
            var instances = _dataService.JobInstances(input);

            if (instances.Count == 0)
                return NoContent();
            else
            {
                var result = JobInstanceMapper.MapList(instances.ResultData);
                result.Page = instances.Page;
                result.PageSize = instances.PageSize;
                return Ok(result);
            }
        }

        // GET api/<JobInstancesController>/UnresolvedErrors
        [HttpGet]
        [Route("UnresolvedErrors")]
        public ActionResult<JobInstances> Get()
        {
            var instances = _dataService.UnresolvedJobErrors();
            if (instances.Count == 0)
                return NoContent();
            else
            {
                var result = JobInstanceMapper.MapList(instances.ResultData);
                result.Page = 1;
                result.PageSize = instances.Count;
                return Ok(result);
            }
        }

        // GET api/<JobInstancesController>/5
        [HttpGet("{id}")]
        public ActionResult<JobInstance> Get(int id)
        {
            var instance = _dataService.JobInstancesById(new(id));

            if (instance.ReturnValue == JobInstancesByIdOutput.Returns.NotFound)
                return NotFound();
            else 
                return Ok(JobInstanceMapper.Map(instance.ResultData));
        }
    }
}
