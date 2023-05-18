using Microsoft.AspNetCore.Mvc;
using SSIS.API.Mappers;
using SSIS.API.Models;
using SSIS.DataService.SSISDB;
using SSIS.DataService.SSISDB.Models;

namespace SSIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageStatisticsController : ControllerBase
    {
        private readonly SSIS.DataService.SSISDB.Service _dataService;

        public PackageStatisticsController (SSIS.DataService.SSISDB.Service dataService)
        {
            _dataService = dataService;
        }

        // GET: api/<PackageStatisticsController>
        [HttpGet]
        public ActionResult<PackageStatistics> Get([FromQuery] int LookbackDays)
        {
            var data = _dataService.PackageExecutionSummary(new(LookbackDays));
            if (data.Count == 0)
                return NoContent();
            else
                return Ok(PackageStatisticMapper.MapOutput(data));
        }

        // GET api/<PackageStatisticsController>/5
        [HttpGet("{id}")]
        public ActionResult<PackageStatistic> Get(int id, [FromQuery] int LookbackDays)
        {
            var data = _dataService.PackageExecutionSummary(new(LookbackDays));
            var package = data.ResultData.FirstOrDefault(i => i.PackageId == id);
            if (package == null)
                return NotFound();
            else
                return Ok(PackageStatisticMapper.Map(package));
        }
    }
}
