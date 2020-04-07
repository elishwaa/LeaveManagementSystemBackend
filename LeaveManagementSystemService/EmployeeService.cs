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
            try
            {
                return _employeeRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<EmployeeType> GetType()
        {
            try
            {
                return _employeeRepository.GetType();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Managers> GetManagers()
        {
            try
            {
                return _employeeRepository.GetManagers();
            }
            catch(Exception ex)
            {
                throw ex;
            }
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
