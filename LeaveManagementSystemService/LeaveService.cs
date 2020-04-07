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

        public IEnumerable<LeaveRequestHistory> GetAllRequest(int id)
        {
            
            return _leaveRepository.GetAllRequest(id);
        }

        public bool Approve(LeaveRequestHistory leave)
        {
            try
            {
                return _leaveRepository.Approve(leave);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Audit(AuditLeaves audit)
        {
            try
            {
                return _leaveRepository.Audit(audit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return _leaveRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Edit(LeaveRequestHistory leaveRequest)
        {
            try
            {
                return _leaveRepository.Edit(leaveRequest);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetLeaveBalance(int id)
        {
            return _leaveRepository.GetLeaveBalance(id);
        }

        public IEnumerable<LeaveRequestHistory> GetRequest(int id)
        {
            return _leaveRepository.GetRequest(id);
        }

        public IEnumerable<Leaves> Get()
        {
            return _leaveRepository.Get();
        }

        public bool Add(LeaveAddRequest newLeave)
        {
            try
            {
                return _leaveRepository.Add(newLeave);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddRequest(LeaveRequest leaverequest)
        {
            try
            {
                return _leaveRepository.AddRequest(leaverequest);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<LeaveTransactions> Transactions(int id)
        {
            return _leaveRepository.Transactions(id);
        }

        public bool EditLeaveBalance(List<EmployeeUpdatedLeaveBalance> leaveBalance)
        {
            try
            {
                return _leaveRepository.EditLeaveBalance(leaveBalance);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
