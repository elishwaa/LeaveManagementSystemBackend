using System;
using System.Collections.Generic;
using System.Linq;
using LeaveManagementSystemModels;
using LeaveManagementSystemService;
using Microsoft.AspNetCore.Mvc;

namespace lmsweb.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private  IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService )
        {
            _employeeService = employeeService;
        }


        [HttpGet]
        [Route("GetEmpType")]
        public ActionResult<IEnumerable<LeaveManagementSystemModels.EmployeeType>> GetEmpType()
        {
            return _employeeService.GetEmpType().ToList();
        }

        [HttpPost]
        [Route("ChangePassword")]
        public bool ChangePassword([FromBody] PasswordChange passwordChange)
        {
            return _employeeService.ChangePassword(passwordChange);
        }

        [HttpGet]
        [Route("ConfirmEmail")]
        public int ConfirmEmail(string emailId)
        {
            return _employeeService.ConfirmEmail(emailId);
        }

        [HttpPost]
        [Route("edit")]
        public bool EditEmployeeDetails(Employee employee)
        {
            return _employeeService.EditEmployeeDetails(employee);
        }

        [HttpGet]
        [Route("allEmployees")]

        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            return _employeeService.GetAllEmployees().ToList();
        }

        [HttpPost]
        [Route("AddEmployee")]
        public bool AddEmployee(NewEmployee employee)
        {
            return _employeeService.AddEmployee(employee);
        }

        [Route("NewDesignation")]
        public bool NewDesignation([FromBody] NewDesignation designation)
        {
            return _employeeService.NewDesignation(designation);
        }

        [HttpGet]
        [Route("GetManagers")]
        public ActionResult<IEnumerable<Managers>> GetManagers()
        {
            return _employeeService.GetManagers().ToList(); 
        }

    }
}
