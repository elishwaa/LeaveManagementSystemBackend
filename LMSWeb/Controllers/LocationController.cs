using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementSystemModels;
using LeaveManagementSystemService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private string message;
        private readonly ILocationService _locationService;
        private readonly ILogger<LocationController> _log;

        public LocationController(ILocationService locationService, ILogger<LocationController> log)
        {
            _locationService = locationService;
            _log = log;

        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] LocationAddRequest location)
        {
            try
            {
                return Ok(_locationService.Add(location));
            }
            catch (Exception ex)
            {
                message = ex.Message;
                _log.LogError(message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }


        [HttpGet]
        [Route("Get")]
        public ActionResult<IEnumerable<Locations>> Get()
        {
            try
            {
                return Ok(_locationService.Get());
            }
            catch (Exception ex)
            {
                message = ex.Message;
                _log.LogError(message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }
    }
}
