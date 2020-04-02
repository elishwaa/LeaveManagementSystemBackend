
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using LMSWeb.Models;
using LeaveManagementSystemService;
using LeaveManagementSystemModels;

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

        [HttpGet]
        [Route("GetEmpType")]
        public IEnumerable<LeaveManagementSystemModels.EmployeeType> GetEmpType()
        {
            return _loginService.GetEmpType();
        }

        [HttpPost]
        [Route("newLogin")]
        public bool NewLogin([FromBody] LeaveManagementSystemModels.NewLogin newLogin)
        {   
            return _loginService.NewLogin(newLogin);
        }
    }
}
