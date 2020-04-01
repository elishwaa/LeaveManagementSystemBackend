using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSWeb.Models
{
    public class NewEmployee
    {
        public int empType { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int salary { get; set; }
        public int manager { get; set; }
        public int project { get; set; }
        public int location { get; set; }
    }
}
