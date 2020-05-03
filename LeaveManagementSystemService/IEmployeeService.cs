using LeaveManagementSystemModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemService
{
    public interface IEmployeeService : IService
    {
        Employee Get(int id);
        int GetEmail(string emailId);
        bool Edit(Employee employee);
        IEnumerable<Employee> GetAll();
        bool Add(EmployeeAddRequest employee);
        bool AddDesignation(EmployeeAddDesignation designation);
        IEnumerable<Managers> GetManagers();
        IEnumerable<EmployeeType> GetType();
    }
}
