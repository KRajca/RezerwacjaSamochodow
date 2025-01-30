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

        // Wy�wietla stron� g��wn�
        public IActionResult Index()
        {
            return View();
        }

        // Wy�wietla stron� z polityk� prywatno�ci
        public IActionResult Privacy()
        {
            return View();
        }

        // Obs�uguje b��dy i wy�wietla odpowiedni komunikat
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
