using IAfest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IAfest.Controllers
{
    public class HomeController : Controller
    {
        // Index
        public IActionResult Index()
        {
            return View();
        }
    }
}