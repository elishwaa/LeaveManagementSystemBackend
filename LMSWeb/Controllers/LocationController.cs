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
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpPost]
        [Route("NewLocation")]
        public bool NewLocation([FromBody] NewLocation newLocation)
        {
            return _locationService.NewLocation(newLocation);
        }


        [HttpGet]
        [Route("GetLocations")]
        public IEnumerable<Locations> GetLocations()
        {
            return _locationService.GetLocations();
        }
    }
}
