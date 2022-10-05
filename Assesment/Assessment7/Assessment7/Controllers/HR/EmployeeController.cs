using Assessment7.Data;
using Assessment7.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment7.Controllers.HR
{
    public class EmployeeController : Controller
    {

        private readonly cabContext _context;
        public EmployeeController(cabContext context)
        {
            _context = context;
        }
        public IActionResult EmpView()
        {
            List<Employees> employee = _context.Employees.ToList();
            return View(employee);
        }
        public IActionResult Details(int Id)
        {
            Employees employee = _context.Employees.Where(p => p.EmployeeId == Id).FirstOrDefault();
            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Employees employee = _context.Employees.Where(p => p.EmployeeId == Id).FirstOrDefault();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employees employee)
        {
            _context.Attach(employee);
            _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("EmpView");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Employees employee = _context.Employees.Where(p => p.EmployeeId == Id).FirstOrDefault();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Delete(Employees employee)
        {
            _context.Attach(employee);
            _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("EmpView");
        }
        [HttpGet]
        public IActionResult Create()
        {
            Employees employee = new Employees();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Create(Employees employee)
        {

            _context.Attach(employee);
            _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("EmpView");
        }
    }
}
