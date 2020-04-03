using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementSystemModels
{
    public class EmployeeUpdatedLeaveBalance
    {
        public int EmployeeId { get; set; }
        public List<LeaveUpdations> Leaves { get; set; }
        public int Year { get; set; }


    }
}
