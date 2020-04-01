using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSWeb.Models
{
    public class Employee
    {
        public int id { get; set; }
        public int typeId { get; set; }
        public string typeName { get; set; }
        public string firstName { get; set; }
        public string middleName{ get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int salary { get; set; }
        public string username { get; set; }
        public int projectId { get; set; }
        public string ProjectName { get; set; }
        public int locationId { get; set; }
        public string locationName { get; set; }
    }
}
