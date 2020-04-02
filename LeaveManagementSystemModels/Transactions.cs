using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementSystemModels
{
    public class Transactions
    {
        public int empId { get; set; }
        public string empName { get; set; }
        public string leaveType { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate  { get; set; }
        public int totaldays { get; set; }
        public string status { get; set; }
    }
}
