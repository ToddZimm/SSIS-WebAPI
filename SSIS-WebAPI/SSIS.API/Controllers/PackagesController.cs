using Microsoft.AspNetCore.Mvc;
using SSIS.API.Mappers;
using SSIS.API.Models;
using SSIS.DataService.SSISDB;
using SSIS.DataService.SSISDB.Models;

namespace SSIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly SSIS.DataService.SSISDB.Service _dataService;

        public PackagesController (SSIS.DataService.SSISDB.Service dataService)
        {
            _dataService = dataService;
        }

        // GET: api/<PackagesController>
        [HttpGet]
        public ActionResult<Packages> Get()
        {
            var packages = _dataService.Packages(new());
            if (packages.Count == 0) 
            {
                return NoContent();
            }
            else
            {
                return Ok(PackageMapper.MapList(packages.ResultData));
            }
        }

        // GET api/<PackagesController>/5
        [HttpGet("{id}")]
        public ActionResult<Package> Get(int id)
        {
            var package = _dataService.PackagesById(new(id));
            if (package.ReturnValue == PackagesByIdOutput.Returns.NotFound)
            {
                return NotFound();
            }
            else
            {
                return Ok(PackageMapper.Map(package.ResultData));
            }
        }
    }
}
