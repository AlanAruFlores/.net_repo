using Microsoft.AspNetCore.Mvc;
using MVC_ModeloParcialMiercoles11Mayo.Models;
using System.Diagnostics;

namespace MVC_ModeloParcialMiercoles11Mayo.Controllers
{
    public class PresentacionController : Controller
    {
        private readonly ILogger<PresentacionController> _logger;

        public PresentacionController(ILogger<PresentacionController> logger)
        {
            _logger = logger;
        }

        public IActionResult Bienvenido()
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
