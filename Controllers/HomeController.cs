using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DayCare.Models;

namespace DayCare.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult formoutput()
        {
            Person p = Factory.Get("STUDENT");
            p.firstName = HttpContext.Request.Form["first_name"];
            p.lastName = HttpContext.Request.Form["last_name"];
            p.phone = Convert.ToInt32(HttpContext.Request.Form["phone"]);
            p.email = HttpContext.Request.Form["Email"];
            p.password = HttpContext.Request.Form["password"];
            p.age = Convert.ToInt32(HttpContext.Request.Form["Age"]);
            p.date_of_birth = Convert.ToDateTime(HttpContext.Request.Form["DateOfBirth"]);
            DayCare.DAO.PersonDAO.save(p);
            return Content(HttpContext.Request.Form["s_name"]);
        }
        public IActionResult Login()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
