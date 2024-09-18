using Microsoft.AspNetCore.Mvc;
using MVC_PracticaParcialUno.Models;
using MVC_PracticaParcialUno.Services;
using System.Diagnostics;

namespace MVC_PracticaParcialUno.Controllers
{
    public class PrincipalController : Controller
    {
        private IPrincipalService _principalService;

        public PrincipalController(IPrincipalService principalService)
        {
            this._principalService = principalService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CalculadoraSumar()
        {
            return View("CalculadoraSumar");
        }

        public IActionResult CalculadoraRestar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult OperarSuma(CalculadoraViewModel mv) {

            if (ModelState.IsValid) {
                ViewBag.Resultado = _principalService.Sumar(mv.NumeroUno, mv.NumeroDos);
            }
            
            return View("CalculadoraSumar", mv);
        }

        [HttpPost]
        public IActionResult OperarResta(CalculadoraViewModel mv)
        {
            if (ModelState.IsValid){
                ViewBag.Resultado = _principalService.Restar(mv.NumeroUno, mv.NumeroDos);
            }

            return View("CalculadoraRestar", mv);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
