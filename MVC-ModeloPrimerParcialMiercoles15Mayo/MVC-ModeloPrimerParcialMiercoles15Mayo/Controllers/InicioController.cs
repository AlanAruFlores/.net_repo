using Microsoft.AspNetCore.Mvc;
using MVC_ModeloPrimerParcialMiercoles15Mayo.Models;
using System.Diagnostics;

namespace MVC_ModeloPrimerParcialMiercoles15Mayo.Controllers
{
    public class InicioController : Controller
    {
        private readonly ILogger<InicioController> _logger;

        public InicioController(ILogger<InicioController> logger)
        {
            _logger = logger;
        }

        public IActionResult Bienvenida() { 
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
