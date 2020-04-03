using System;
using System.Collections.Generic;
using System.Linq;
using LeaveManagementSystemModels;
using LeaveManagementSystemService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lmsweb.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private string message;
        private  IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService )
        {
            _employeeService = employeeService;
        }


        [HttpGet]
        [Route("GetType")]
        public IEnumerable<EmployeeType> GetType()
        {
            return _employeeService.GetType();
        }

        [HttpPost]
        [Route("EditPassword")]
        public IActionResult EditPassword([FromBody] EmployeePasswordChange passwordChange)
        {
            try
            {
                return Ok( _employeeService.EditPassword(passwordChange));
            }
            catch(Exception ex)
            {
                message = ex.Message;
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
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [HttpGet]
        [Route("GetAll")]

        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            return _employeeService.GetAll().ToList();
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
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [HttpGet]
        [Route("GetManagers")]
        public ActionResult<IEnumerable<Managers>> GetManagers()
        {
            return _employeeService.GetManagers().ToList(); 
        }

    }
}
