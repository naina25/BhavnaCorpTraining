using Assessment7.Data;
using Assessment7.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment7.Controllers.Admin
{
    public class AdminController : Controller
    {
        private readonly cabContext _context;

        public AdminController(cabContext context)
        {
            _context = context;
        }
        public IActionResult Entry()
        {
            List<Managers> managersInfo = _context.Managers.ToList();
            return View(managersInfo);
        }
        public IActionResult GetDetails(int Id)
        {
            Managers manager = _context.Managers.Where(m => m.ManagerId == Id).FirstOrDefault();
            return View(manager);
        }

        [HttpGet]
        public IActionResult EditManager(int Id)
        {
            Managers manager = _context.Managers.Where(m => m.ManagerId == Id).FirstOrDefault();
            return View(manager);
        }
        [HttpPost]
        public IActionResult EditManager(Managers manager)
        {
            _context.Attach(manager);
            _context.Entry(manager).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Entry");
        }

        [HttpGet]
        public IActionResult DeleteManager(int Id)
        {
            Managers manager = _context.Managers.Where(m => m.ManagerId == Id).FirstOrDefault();
            return View(manager);
        }
        [HttpPost]
        public IActionResult DeleteManager(Managers manager)
        {
            _context.Attach(manager);
            _context.Entry(manager).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Entry");
        }

        [HttpGet]
        public IActionResult Create()
        {
            Managers manager = new Managers();
            return View(manager);
        }
        [HttpPost]
        public IActionResult Create(Managers manager)
        {

            _context.Attach(manager);
            _context.Entry(manager).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("Entry");
        }
    }
}
