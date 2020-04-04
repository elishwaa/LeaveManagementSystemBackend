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

        public bool Add(EmployeeAddRequest employee)
        {
            try
            {
                return _employeeRepository.Add(employee);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public int GetEmail(string emailId)
        {
            try
            {
                return _employeeRepository.GetEmail(emailId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Edit(Employee employee)
        {
            try
            {
                return _employeeRepository.Edit(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public IEnumerable<EmployeeType> GetType()
        {
            return _employeeRepository.GetType();
        }

        public IEnumerable<Managers> GetManagers()
        {
            return _employeeRepository.GetManagers();
        }

        public bool AddDesignation(EmployeeAddDesignation designation)
        {
            try
            {
                return _employeeRepository.AddDesignation(designation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
