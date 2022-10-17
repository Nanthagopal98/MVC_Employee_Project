using Employee_Payroll.Models;
using Employee_Payroll.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Payroll.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee employee;

        public EmployeeController(IEmployee employee)
        {
            this.employee = employee;
        }
         
        public IActionResult listEmployee()
        {
            List<GetEmployeeModel> empList = new List<GetEmployeeModel>();
            empList =  this.employee.GetEmployee().ToList();
            return View(empList);
        }

        [HttpGet]
        public IActionResult AddEmp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmp([Bind] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                employee.AddEmployee(employeeModel);
                return RedirectToAction("listEmployee");
            }
            return View(employeeModel);
        }
        public IActionResult get()
        {
            return View();
        }
    }
}
