using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RezerwacjaSamochodow.Models;

namespace RezerwacjaSamochodow.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Wyœwietla stronê g³ówn¹
        public IActionResult Index()
        {
            return View();
        }

        // Wyœwietla stronê z polityk¹ prywatnoœci
        public IActionResult Privacy()
        {
            return View();
        }

        // Obs³uguje b³êdy i wyœwietla odpowiedni komunikat
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
