using LeaveManagementSystemModels;
using LeaveManagementSystemRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemService
{
    public class LeaveService : ILeaveService
    {
        private readonly ILeaveRepository _leaveRepository;

        public LeaveService(ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }

        public IEnumerable<LeaveRequestHistory> AllLeaveRequests(int id)
        {
            return _leaveRepository.AllLeaveRequests(id);
        }

        public bool ApproveLeaveRequest(LeaveRequestHistory leave)
        {
            return _leaveRepository.ApproveLeaveRequest(leave);
        }

        public bool AuditProcess(AuditLeaves audit)
        {
            return _leaveRepository.AuditProcess(audit);
        }

        public bool DeleteRequest(int id)
        {
            return _leaveRepository.DeleteRequest(id);
        }

        public bool EditAndApprove(LeaveRequestHistory leaveRequest)
        {
            return _leaveRepository.EditAndApprove(leaveRequest);
        }

        public string GetLeaveBalance(int id)
        {
            return _leaveRepository.GetLeaveBalance(id);
        }

        public IEnumerable<LeaveRequestHistory> GetLeaveRequests(int id)
        {
            return _leaveRepository.GetLeaveRequests(id);
        }

        public IEnumerable<Leaves> GetLeaves()
        {
            return _leaveRepository.GetLeaves();
        }

        public bool NewLeave(NewLeave newLeave)
        {
            return _leaveRepository.NewLeave(newLeave);
        }

        public bool SaveLeaveRequests(LeaveRequest leaverequest)
        {
            return _leaveRepository.SaveLeaveRequests(leaverequest);
        }

        public IEnumerable<Transactions> Transactions(int id)
        {
            return _leaveRepository.Transactions(id);
        }

        public bool UpdateLeaveBalance(List<EmployeeUpdatedLeaveBalance> leaveBalance)
        {
            return _leaveRepository.UpdateLeaveBalance(leaveBalance);
        }
    }
}
