using LeaveManagementSystemModels;
using LeaveManagementSystemRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public bool AddEmployee(NewEmployee employee)
        {
            return _employeeRepository.AddEmployee(employee);
        }

        public bool ChangePassword(PasswordChange passwordChange)
        {
            return _employeeRepository.ChangePassword(passwordChange);
        }

        public int ConfirmEmail(string emailId)
        {
            return _employeeRepository.ConfirmEmail(emailId);
        }

        public bool EditEmployeeDetails(Employee employee)
        {
            return _employeeRepository.EditEmployeeDetails(employee);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }

        public IEnumerable<EmployeeType> GetEmpType()
        {
            return _employeeRepository.GetEmpType();
        }

        public IEnumerable<Managers> GetManagers()
        {
            return _employeeRepository.GetManagers();
        }

        public bool NewDesignation(NewDesignation designation)
        {
            return _employeeRepository.NewDesignation(designation);
        }
    }
}
