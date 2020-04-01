using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSWeb.Models
{
    public class EmployeeUpdatedLeaveBalance
    {
        public int employeeId { get; set; }
        public List<UpdatedLeaves> leaves { get; set; }
        public int year { get; set; }


    }
}
