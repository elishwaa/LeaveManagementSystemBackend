
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LeaveManagementSystemService;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System;
using LeaveManagementSystemModels;

namespace LMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private  string message;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;

        }

        [HttpPost]
        [Route("Get")]
        public ActionResult<LeaveManagementSystemModels.Employee> Get(LeaveManagementSystemModels.LoginDetails loginDetails)
        {
            try
            {
                return Ok(_loginService.Get(loginDetails));
            }
            catch(Exception ex)
            {
                var message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] LeaveManagementSystemModels.Login login)
        {
            try
            {
                return Ok(_loginService.Add(login));
            }
            catch(Exception ex)
            {
                var message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [HttpPost]
        [Route("EditPassword")]
        public IActionResult EditPassword([FromBody] EmployeePasswordChange passwordChange)
        {
            try
            {
                return Ok(_loginService.EditPassword(passwordChange));
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }
    }
}
