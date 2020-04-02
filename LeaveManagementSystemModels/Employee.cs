using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementSystemModels
{
    public class Employee
    {
        public int typeid;

        public int Id { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName{ get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public string Username { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
