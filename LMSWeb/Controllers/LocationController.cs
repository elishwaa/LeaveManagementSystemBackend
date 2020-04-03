using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementSystemModels;
using LeaveManagementSystemService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private string message;
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
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
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }


        [HttpGet]
        [Route("Get")]
        public IEnumerable<Locations> Get()
        {
            //try
            //{
                return _locationService.Get();
            //}
            //catch(Exception ex) {
            //    message = ex.Message;
            //    return BadRequest(message);
            //}
        }
    }
}
