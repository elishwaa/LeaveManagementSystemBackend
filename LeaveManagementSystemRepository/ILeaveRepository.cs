using LeaveManagementSystemModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemRepository
{
    public interface ILeaveRepository : IRepository
    {
        bool SaveLeaveRequests(LeaveRequest leaverequest);
        IEnumerable<LeaveRequestHistory> GetLeaveRequests(int id);
        IEnumerable<LeaveRequestHistory> AllLeaveRequests(int id);
        bool DeleteRequest(int id);
        bool EditAndApprove(LeaveRequestHistory leaveRequest);
        bool ApproveLeaveRequest(LeaveRequestHistory leave);
        bool NewLeave(NewLeave newLeave);
        IEnumerable<Transactions> Transactions(int id);
        IEnumerable<Leaves> GetLeaves();
        string GetLeaveBalance(int id);
        bool AuditProcess(AuditLeaves audit);
        bool UpdateLeaveBalance(List<EmployeeUpdatedLeaveBalance> leaveBalance);
    }
}
