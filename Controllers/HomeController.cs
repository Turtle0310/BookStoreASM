using Final_Asm.Data;
using Final_Asm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Final_Asm.Controllers
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string fname,string lname, Customer customer) 
        {
            if (ModelState.IsValid)
            {
               
            }
            return View();
        }

    }
}