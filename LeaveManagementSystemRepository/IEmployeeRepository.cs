using LeaveManagementSystemModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemRepository
{
    public interface IEmployeeRepository : IRepository
    {
        bool EditPassword(EmployeePasswordChange passwordChange);
        int GetEmail(string emailId);
        bool Edit(Employee employee);
        IEnumerable<Employee> GetAll();
        bool Add(EmployeeAddRequest employee);
        bool AddDesignation(EmployeeAddDesignation designation);
        IEnumerable<Managers> GetManagers();
        IEnumerable<EmployeeType> GetType();
    }
}
