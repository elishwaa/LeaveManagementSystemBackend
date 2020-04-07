using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementSystemModels;
using LeaveManagementSystemService;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private string message;
        private readonly IProjectService _projectService;
        private readonly ILogger<ProjectController> _log;
        public ProjectController(IProjectService projectService, ILogger<ProjectController> log)
        {
            _projectService = projectService;
            _log = log;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] ProjectAddRequest project)
        {
            try
            {
                return Ok(_projectService.Add(project));           
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
        public ActionResult<IEnumerable<Projects>> Get()
        {
            try
            {
                return Ok(_projectService.Get());
            }
            catch (Exception ex)
            {
                message = ex.Message;
                _log.LogError(message);
                return null;
            }
        }
    }
}
