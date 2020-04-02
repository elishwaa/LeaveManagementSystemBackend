
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LeaveManagementSystemService;
using System.Linq;

namespace LMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;

        }

        [HttpPost]
        [Route("GetLogin")]
        public ActionResult<LeaveManagementSystemModels.Employee> GetLogin(LeaveManagementSystemModels.LoginDetails loginDetails)
        {
            var employee = _loginService.GetLogin(loginDetails);
            return employee;
        }

        [HttpPost]
        [Route("newLogin")]
        public bool NewLogin([FromBody] LeaveManagementSystemModels.NewLogin newLogin)
        {   
            return _loginService.NewLogin(newLogin);
        }
    }
}
