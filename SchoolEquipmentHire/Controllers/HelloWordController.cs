using Microsoft.AspNetCore.Mvc;
using SchoolEquipmentHire.Models;
using System.Diagnostics;

namespace SchoolEquipmentHire.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }
    }
}
