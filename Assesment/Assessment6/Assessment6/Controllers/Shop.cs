using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment6.Controllers
{
    public class Shop : Controller
    {
        public IActionResult EntryPage()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }
    }
}
