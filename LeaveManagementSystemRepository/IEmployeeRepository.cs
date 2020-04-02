using LeaveManagementSystemModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemRepository
{
    public interface IEmployeeRepository : IRepository
    {
        bool ChangePassword(PasswordChange passwordChange);
        int ConfirmEmail(string emailId);
        bool EditEmployeeDetails(Employee employee);
        IEnumerable<Employee> GetAllEmployees();
        bool AddEmployee(NewEmployee employee);
        bool NewDesignation(NewDesignation designation);
        IEnumerable<Managers> GetManagers();
        IEnumerable<EmployeeType> GetEmpType();
    }
}
