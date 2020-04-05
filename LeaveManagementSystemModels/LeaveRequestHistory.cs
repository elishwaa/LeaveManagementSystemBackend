using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementSystemModels { 
    public class LeaveRequestHistory
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string EmployeeName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int LeaveId { get; set; }
        public string Leave { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
    }
}
