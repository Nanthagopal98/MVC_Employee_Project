using Microsoft.VisualBasic;
using System;

namespace Employee_Payroll.Models
{
    public class EmployeeModel
    {
        public string Name { get; set; }
        public string Profile { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
    }
}
