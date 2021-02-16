using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralDepartment.Models
{
    public class Employee
    {
        public int EmplyeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public int DateJoin { get; set; }
        public string ProfilePhoto { get; set; }
    }
}
