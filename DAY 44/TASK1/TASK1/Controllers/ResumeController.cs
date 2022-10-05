using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK1.Data;
using TASK1.Models;

namespace TASK1.Controllers
{
    public class ResumeController : Controller
    {
        private readonly ResumeDBContext _context;
        public ResumeController(ResumeDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Applicant> applicants;
            applicants = _context.Applicants.ToList();
            return View(applicants);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Applicant applicant = new Applicant();
            applicant.Experiences.Add(new Experience() { ExperienceId = 1 });
            //applicant.Experiences.Add(new Experience() { ExperienceId = 2 });
            //applicant.Experiences.Add(new Experience() { ExperienceId = 3 });
            return View(applicant);
        }

        [HttpPost]
        public IActionResult Create(Applicant applicant)
        {
            _context.Add(applicant);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
