using Employee_Payroll.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Employee_Payroll.Repository
{
    public interface IEmployee
    {
        bool AddEmployee(EmployeeModel employeeModel);
        bool DeleteEmployee(int employeeId);
        List<GetEmployeeModel> GetEmployee();
        bool UpdateEmployee(GetEmployeeModel employeeModel);
    }
}