using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementSystemModels
{
    public class LeaveBalance
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public int CasualLeave { get; set; }
        public int SickLeave { get; set; }
        public int Other { get; set; }
    }
}
