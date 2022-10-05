using Assessment7.Data;
using Assessment7.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class TravelController : Controller
    {
        private readonly cabContext _context;
        public TravelController(cabContext context)
        {
            _context = context;
        }
        public IActionResult TravelView()
        {
            List<Travel> tra = _context.Travel.ToList();
            return View(tra);
        }
        public IActionResult Details(string Id)
        {
            Travel tra = _context.Travel.Where(p => p.RouteId == Id).FirstOrDefault();
            return View(tra);
        }
        [HttpGet]
        public IActionResult Edit(string Id)
        {
            Travel tra = _context.Travel.Where(p => p.RouteId == Id).FirstOrDefault();
            return View(tra);
        }
        [HttpPost]
        public IActionResult Edit(Travel tra)
        {
            _context.Attach(tra);
            _context.Entry(tra).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("TravelView");
        }
        [HttpGet]
        public IActionResult Delete(string Id)
        {
            Travel tra = _context.Travel.Where(p => p.RouteId == Id).FirstOrDefault();
            return View(tra);
        }
        [HttpPost]
        public IActionResult Delete(Travel tra)
        {
            _context.Attach(tra);
            _context.Entry(tra).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("TravelView");
        }
        [HttpGet]
        public IActionResult Create()
        {
            Travel tra = new Travel();
            return View(tra);
        }
        [HttpPost]
        public IActionResult Create(Travel tra)
        {

            _context.Attach(tra);
            _context.Entry(tra).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("TravelView");
        }
    }
}
