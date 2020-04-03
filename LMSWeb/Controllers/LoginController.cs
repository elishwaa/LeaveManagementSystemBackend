﻿
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LeaveManagementSystemService;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System;

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
        [Route("Login")]
        public IActionResult Add([FromBody] LeaveManagementSystemModels.Login login)
        {
            try
            {
                return Ok(_loginService.Login(login));
            }
            catch(Exception ex)
            {
                var message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }
    }
}
