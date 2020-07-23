using LeaveManagementSystemModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemRepository
{
    public interface IEmployeeRepository : IRepository
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
