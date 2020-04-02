using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementSystemModels
{
    public class Transactions
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate  { get; set; }
        public int Totaldays { get; set; }
        public string Status { get; set; }
    }
}
