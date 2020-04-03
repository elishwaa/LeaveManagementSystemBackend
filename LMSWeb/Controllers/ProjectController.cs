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
    public class ProjectController : ControllerBase
    {
        private string message;
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
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
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

        }


        [HttpGet]
        [Route("Get")]
        public IEnumerable<Projects> Get()
        {
            return _projectService.Get();
        }
    }
}
