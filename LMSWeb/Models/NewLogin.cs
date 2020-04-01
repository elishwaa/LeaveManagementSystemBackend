using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSWeb.Models
{
    public class NewLogin
    {
        public int employeeId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
