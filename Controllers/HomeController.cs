using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DayCare.Models;
using DayCare.DAO;

namespace DayCare.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Student p;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            TeacherDAO.readFile();
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
            p = (Student)Factory.Get("STUDENT");
            p.firstName = HttpContext.Request.Form["first_name"];
            p.lastName = HttpContext.Request.Form["last_name"];
            p.phone = Convert.ToInt64(HttpContext.Request.Form["phone"]);
            p.email = HttpContext.Request.Form["Email"];
            p.password = HttpContext.Request.Form["password"];
            p.date_of_birth = Convert.ToDateTime(HttpContext.Request.Form["DateOfBirth"]);
            p.age = p.Age(p.date_of_birth);
           
            DayCare.DAO.PersonDAO.save(p);

            p.teacher = Teacher.assignTeacher(p);
            p.room = Teacher.assignRoom(p, p.teacher);
                       
            return Output();

        }
        public IActionResult Output()
        {

            ViewData["myperson"] = p;
            return View();
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
