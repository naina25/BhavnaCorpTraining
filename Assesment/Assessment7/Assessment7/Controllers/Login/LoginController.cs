using Assessment7.Data;
using Assessment7.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabService.Controllers
{
    public class LoginController : Controller
    {
        private readonly cabContext _context;

        public LoginController(cabContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginView()
        {
            List<Login> loginList = _context.Login.ToList();

            return View(loginList);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            List<Login> loginList = _context.Login.ToList();

            foreach(Login user in loginList)
            {
                if(login.LogId == user.LogId && login.Password == user.Password)
                {
                    if (login.LogId == "admin")
                        return Redirect("~/Admin/Entry");
                    else if (login.LogId == "hr")
                        return Redirect("~/Employee/EmpView");
                    else if(login.LogId == "finance")
                        return Redirect("~/Finance/FinanceEntry");
                    else if(login.LogId == "travel")
                        return Redirect("~/Travel/TravelView");

                }    
            }
            
            return Redirect("~/Home/Index");
        }
    }
}
