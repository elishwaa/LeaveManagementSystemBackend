using LeaveManagementSystemModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemRepository
{
    public interface ILeaveRepository : IRepository
    {
        bool AddRequest(LeaveRequest leaverequest);
        IEnumerable<LeaveRequestHistory> GetRequest(int id);
        IEnumerable<LeaveRequestHistory> GetAllRequest(int id);
        bool Delete(int id);
        bool Edit(LeaveRequestHistory leaveRequest);
        bool Approve(LeaveRequestHistory leave);
        bool Add(LeaveAddRequest newLeave);
        IEnumerable<LeaveTransactions> Transactions(int id);
        IEnumerable<Leaves> Get();
        string GetLeaveBalance(int id);
        bool Audit(AuditLeaves audit);
        bool EditLeaveBalance(List<EmployeeUpdatedLeaveBalance> leaveBalance);
    }
}
