using System;

namespace Employee_Payroll.Models
{
    public class GetEmployeeModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Profile { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public string StartDate { get; set; }
    }
}
