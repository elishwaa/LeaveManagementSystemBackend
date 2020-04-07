using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementSystemModels
{
    public class EmployeeAddRequest
    {
        public int EmpType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public int Manager { get; set; } 
        public int Project { get; set; }
        public int Location { get; set; }
    }
}
