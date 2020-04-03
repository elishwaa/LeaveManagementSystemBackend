using System;
using System.Collections.Generic;
using LeaveManagementSystemModels;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Newtonsoft.Json;
using LeaveManagementSystemService;
using Microsoft.AspNetCore.Http;

namespace LMSWeb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService _leaveService;
        private string message;
        public LeaveController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }
        

        [HttpPost]
        [Route("AddRequest")]
        public IActionResult AddRequest(LeaveRequest leaverequest)
        {
            try
            {
                return Ok( _leaveService.AddRequest(leaverequest));
            }
            catch(Exception ex)
            {
                message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [HttpGet]
        [Route("GetRequest")]
        public IEnumerable<LeaveRequestHistory> GetRequest(int id)
        {
            return _leaveService.GetRequest(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<LeaveRequestHistory> GetAllRequest(int id)
        {
            return _leaveService.GetAllRequest(id);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_leaveService.Delete(id));
            }
            catch(Exception ex)
            {
                message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(LeaveRequestHistory leaveRequest)
        {
            try
            {
                return Ok(_leaveService.Edit(leaveRequest));
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

        }
        [HttpPost]
        [Route("Approve")]
        public IActionResult Approve(LeaveRequestHistory leave)
        {
            try
            {
                return Ok( _leaveService.Approve(leave));
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] LeaveAddRequest newLeave)
        {
            try
            {
                return Ok( _leaveService.Add(newLeave));
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [HttpGet]
        [Route("Transactions")]
        public IEnumerable<LeaveTransactions> Transactions(int id)
        {
            return _leaveService.Transactions(id);
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<Leaves> Get()
        {
            return _leaveService.Get();
        }

        [HttpGet]
        [Route("GetLeaveBalance")]
        public string GetLeaveBalance(int id)
        {
            return _leaveService.GetLeaveBalance(id);
        }

        [HttpPost]
        [Route("Audit")]
        public IActionResult Audit(AuditLeaves audit)
        {
            try
            {
                return Ok( _leaveService.Audit(audit));
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [HttpPost]
        [Route("EditLeaveBalance")]

        public IActionResult EditLeaveBalance([FromBody] List<EmployeeUpdatedLeaveBalance> leaveBalance)
        {
            try
            {
                return Ok( _leaveService.EditLeaveBalance(leaveBalance));
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

    }

}

