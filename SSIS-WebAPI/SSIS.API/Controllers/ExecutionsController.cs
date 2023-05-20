using Microsoft.AspNetCore.Mvc;
using SSIS.API.Models;
using SSIS.API.Mappers;
using SSIS.DataService.SSISDB.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SSIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExecutionsController : ControllerBase
    {
        private readonly SSIS.DataService.SSISDB.Service _dataService;

        public ExecutionsController(SSIS.DataService.SSISDB.Service dataService)
        {
            _dataService = dataService;
        }

        // GET: api/<ExecutionsController>
        [HttpGet]
        public ActionResult<Executions> Get([FromQuery] int? page,
            [FromQuery] int? pageSize, [FromQuery] long? packageId, [FromQuery] int? status,
            [FromQuery] DateTime? startTime, [FromQuery] DateTime? endTime)
        {
            var results = _dataService.Executions(new DataService.SSISDB.Models.ExecutionsInput()
            {
                Page = page,
                PageSize = pageSize,
                PackageId = packageId,
                Status = status,
                EndTime = endTime,
                StartTime = startTime,
            });

            if (results.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(ExecutionMapper.MapList(results));
            }
        }

        // GET api/<ExecutionsController>/UnresolvedErrors
        [HttpGet]
        [Route("api/[Controller]/UnresolvedErrors")]
        public ActionResult<Executions> Get()
        {
            var results = _dataService.UnresolvedExecutionErrors();
            if (results.Count == 0)
                return NoContent();
            else
                return Ok(ExecutionMapper.MapList(results));
        }

        // GET api/<ExecutionsController>/5
        [HttpGet("{id}")]
        public ActionResult<Execution> Get(long id, [FromQuery] bool verboseMessages = false)
        {
            var result = _dataService.ExecutionsById(new(id));
            if (result.ReturnValue == ExecutionsByIdOutput.Returns.NotFound)
            {
                return NotFound();
            }
            else 
            {
                var messages = _dataService.ExecutionMessages(new(id, !verboseMessages));
                return Ok(ExecutionMapper.Map(result.ResultData, messages.ResultData)); 
            }
        }
    }
}
