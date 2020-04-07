using System;
using System.Collections.Generic;
using System.Linq;
using LeaveManagementSystemModels;
using LeaveManagementSystemService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lmsweb.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private string message;
        private  IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _log;

        public EmployeeController(IEmployeeService employeeService , ILogger<EmployeeController> log)
        {
            _employeeService = employeeService;
            _log = log;

        }


        [HttpGet]
        [Route("GetType")]
        public  ActionResult<IEnumerable<EmployeeType>> GetType()
        {
            try
            {
                return Ok(_employeeService.GetType());
            }
            catch(Exception ex)
            {
                message = ex.Message;
                _log.LogError(message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        

        [HttpGet]
        [Route("GetEmail")]
        public IActionResult GetEmail(string emailId)
        {
            try
            {
                return Ok(_employeeService.GetEmail(emailId));
            }
            catch(Exception ex)
            {
                message = ex.Message;
                _log.LogError(message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(Employee employee)
        {
            try
            {
                return Ok(_employeeService.Edit(employee));
            }
            catch (Exception ex)
            {
                message = ex.Message;
                _log.LogError(message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [HttpGet]
        [Route("GetAll")]

        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            try
            {
                return _employeeService.GetAll().ToList();
            }
            catch(Exception ex)
            {
                message = ex.Message;
                _log.LogError(message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(EmployeeAddRequest employee)
        {
            try
            {
                return Ok( _employeeService.Add(employee));
            }
            catch (Exception ex)
            {
                message = ex.Message;
                _log.LogError(message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [Route("AddDesignation")]
        public IActionResult AddDesignation([FromBody] EmployeeAddDesignation designation)
        {
            try
            {
                return Ok(_employeeService.AddDesignation(designation));
            }
            catch (Exception ex)
            {
                message = ex.Message;
                _log.LogError(message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [HttpGet]
        [Route("GetManagers")]
        public ActionResult<IEnumerable<Managers>> GetManagers()
        {
            try
            {
                return Ok(_employeeService.GetManagers());
            }
            catch(Exception ex)
            {
                message = ex.Message;
                _log.LogError(message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

    }
}
