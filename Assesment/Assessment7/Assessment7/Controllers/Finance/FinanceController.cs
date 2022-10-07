using Assessment7.Data;
using Assessment7.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Assessment7.Controllers.Finance
{
    public class FinanceController : Controller
    {
        private readonly cabContext _context;
        public FinanceController(cabContext context)
        {
            _context = context;
        }
        public IActionResult FinanceEntry()
        {
            List<Assessment7.Models.Finance> finance = _context.Finance.ToList();
            return View(finance);
        }
        public IActionResult Details(int Id)
        {
            Assessment7.Models.Finance fin = _context.Finance.Where(p => p.TransactionId == Id).FirstOrDefault();
            return View(fin);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Assessment7.Models.Finance fin = _context.Finance.Where(p => p.TransactionId == Id).FirstOrDefault();
            return View(fin);
        }
        [HttpPost]
        public IActionResult Edit(Assessment7.Models.Finance fin)
        {
            _context.Attach(fin);
            _context.Entry(fin).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("FinanceEntry");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
             Assessment7.Models.Finance fin = _context.Finance.Where(p => p.TransactionId == Id).FirstOrDefault();
            return View(fin);
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
            Assessment7.Models.Finance finance = new Assessment7.Models.Finance();
            return View(finance);
        }
        [HttpPost]
        public IActionResult Create(Assessment7.Models.Finance finance)
        {
            _context.Attach(finance);
            _context.Entry(finance).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("FinanceEntry");
        }
    }
}
