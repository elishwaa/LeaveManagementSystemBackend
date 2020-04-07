
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LeaveManagementSystemService;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System;
using LeaveManagementSystemModels;
using Microsoft.Extensions.Logging;

namespace LMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private  string message;
        private readonly ILogger<LoginController> _log;


        public LoginController(ILoginService loginService, ILogger<LoginController> log)
        {
            _loginService = loginService;
            _log = log;
        }

        [HttpPost]
        [Route("Get")]
        public ActionResult<Employee> Get(LoginDetails loginDetails)
        {
            try
            {
                return Ok(_loginService.Get(loginDetails));
            }
            catch(Exception ex)
            {
                var message = ex.Message;
                _log.LogError(message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] Login login)
        {
            try
            {
                return Ok(_loginService.Add(login));
            }
            catch(Exception ex)
            {
                var message = ex.Message;
                _log.LogError(message);
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
                _log.LogError(message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }
    }
}
