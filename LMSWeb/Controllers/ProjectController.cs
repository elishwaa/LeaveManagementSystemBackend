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
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        [Route("NewProject")]
        public bool NewProject([FromBody] NewProject newProject)
        {
            return _projectService.NewProject(newProject);
        }


        [HttpGet]
        [Route("GetProjects")]
        public IEnumerable<Projects> GetProjects()
        {
            return _projectService.GetProject();

        }
    }
}
