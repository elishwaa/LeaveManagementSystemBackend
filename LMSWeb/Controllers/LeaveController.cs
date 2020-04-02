using System;
using System.Collections.Generic;
using LeaveManagementSystemModels;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Newtonsoft.Json;
using LeaveManagementSystemService;

namespace LMSWeb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService _leaveService;
        public LeaveController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }
        

        [HttpPost]
        [Route("SaveLeave")]
        public bool SaveLeaveRequests(LeaveRequest leaverequest)
        {
            return _leaveService.SaveLeaveRequests(leaverequest);
        }

        [HttpGet]
        [Route("GetLeaveRequests")]
        public IEnumerable<LeaveRequestHistory> GetLeaveRequests(int id)
        {
            return _leaveService.GetLeaveRequests(id);
        }

        [HttpGet]
        [Route("allLeaveRequests")]
        public IEnumerable<LeaveRequestHistory> AllLeaveRequests(int id)
        {
            return _leaveService.AllLeaveRequests(id);
        }

        [HttpDelete]
        [Route("delete")]
        public bool DeleteRequest(int id)
        {
            return _leaveService.DeleteRequest(id);
        }

        [HttpPost]
        [Route("EditAndApprove")]
        public bool EditAndApprove(LeaveRequestHistory leaveRequest)
        {
            return _leaveService.EditAndApprove(leaveRequest);

        }
        [HttpPost]
        [Route("Approve")]
        public bool ApproveLeaveRequest(LeaveRequestHistory leave)
        {
            return _leaveService.ApproveLeaveRequest(leave);
        }

        [HttpPost]
        [Route("NewLeave")]
        public bool NewLeave([FromBody] NewLeave newLeave)
        {
            return _leaveService.NewLeave(newLeave);
        }

        [HttpGet]
        [Route("Transactions")]
        public IEnumerable<Transactions> Transactions(int id)
        {
            return _leaveService.Transactions(id);
        }

        [HttpGet]
        [Route("GetLeaves")]
        public IEnumerable<Leaves> GetLeaves()
        {
            return _leaveService.GetLeaves();
        }

        [HttpGet]
        [Route("GetLeaveBalance")]
        public string GetLeaveBalance(int id)
        {
            return _leaveService.GetLeaveBalance(id);
        }

        [HttpPost]
        [Route("audit")]
        public bool AuditProcess(AuditLeaves audit)
        {
            return _leaveService.AuditProcess(audit);
        }

        [HttpPost]
        [Route("editLeaveBalance")]

        public bool UpdateLeaveBalance([FromBody] List<EmployeeUpdatedLeaveBalance> leaveBalance)
        {
            return _leaveService.UpdateLeaveBalance(leaveBalance);
        }

    }

}

