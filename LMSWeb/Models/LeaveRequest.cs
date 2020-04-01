using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSWeb.Models
{
    public class LeaveRequest
    {
        public int empId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int leave { get; set; }
        public string reason { get; set; }
    }
}
