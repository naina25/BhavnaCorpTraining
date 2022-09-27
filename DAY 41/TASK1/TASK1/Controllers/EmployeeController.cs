using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK1.Models;

namespace TASK1.Controllers
{
    public class EmployeeController : Controller
    {
        public ViewResult Details()
        {
            Employee emp = new Employee()
            {
                employeeId = 101,
                employeeName = "Naina Upadhyay",
                gender = "Female",
                salary = 55000
            };

            Department dept = new Department()
            {
                employeeId = 101,
                departmentId = 201,
                departmentName = "IT",
                totalEmployees = 1000
            };

            EmployeeDetailsViewModel empDetailsViewModel = new EmployeeDetailsViewModel()
            {
                employee = emp,
                department = dept,
                Title = "Employee Details",
                Header = "Employee Data"
            };
            return View(empDetailsViewModel);
        }
    }
}
