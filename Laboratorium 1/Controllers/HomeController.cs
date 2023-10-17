using Laboratorium_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Laboratorium_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public enum Operators 
        { 
            ADD, SUB, MUL, DIV,
        }

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

        public IActionResult About([FromQuery(Name = "app-author")]string author) 
        {
            //string author = Request.Query["author"];

            ViewBag.Author = author;
            return View();
        }

        public IActionResult Calculator([FromQuery(Name = "operator")] string op, double? a, double? b)
        {
            if (a == null || b == null)
            {
                return View("Error");
            }

            switch(op)
            {
                case Operators.ADD:
                    ViewBag.result = a + b;
                    break;
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}