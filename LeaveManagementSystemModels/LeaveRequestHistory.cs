using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementSystemModels { 
    public class LeaveRequestHistory
    {
        public int id { get; set; }
        public int empId { get; set; }
        public string employeeName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int leaveId { get; set; }
        public string leave { get; set; }
        public string status { get; set; }
        public string reason { get; set; }
    }
}
