using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSWeb.Models
{
    public class LeaveBalance
    {
        public int id { get; set; }
        public string employeeName { get; set; }
        public int casualLeave { get; set; }
        public int sickLeave { get; set; }
        public int other { get; set; }
    }
}
