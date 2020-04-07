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
using Microsoft.Extensions.Logging;

namespace LMSWeb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService _leaveService;
        private string message;
        private readonly ILogger<LeaveController> _log;

        public LeaveController(ILeaveService leaveService, ILogger<LeaveController> log)
        {
            _leaveService = leaveService;
            _log = log;

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
                _log.LogError(message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [HttpGet]
        [Route("GetRequest")]
        public ActionResult<IEnumerable<LeaveRequestHistory>> GetRequest(int id)
        {
            try
            {
                return Ok(_leaveService.GetRequest(id));
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
        public ActionResult<IEnumerable<LeaveRequestHistory>> GetAllRequest(int id)
        {
            try
            {
                return Ok(_leaveService.GetAllRequest(id));
            }
            catch (Exception ex)
            {
                message = ex.Message;
                _log.LogError(message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
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
                _log.LogError(message);
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
                _log.LogError(message);
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
                _log.LogError(message);
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
                _log.LogError(message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [HttpGet]
        [Route("Transactions")]
        public ActionResult<IEnumerable<LeaveTransactions>> Transactions(int id)
        {
            try
            {
                return Ok(_leaveService.Transactions(id));
            }
            catch(Exception ex)
            {
                message = ex.Message;
                _log.LogError(message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [HttpGet]
        [Route("Get")]
        public ActionResult<IEnumerable<Leaves>> Get()
        {
            try
            {
                return Ok(_leaveService.Get());
            }
            catch (Exception ex)
            {
                message = ex.Message;
                _log.LogError(message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [HttpGet]
        [Route("GetLeaveBalance")]
        public ActionResult<string> GetLeaveBalance(int id)
        {
            try
            {
                return Ok(_leaveService.GetLeaveBalance(id));
            }
            catch(Exception ex)
            {
                message = ex.Message;
                _log.LogError(message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
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
                _log.LogError(message);
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
                _log.LogError(message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

    }

}

