using Microsoft.AspNetCore.Mvc;
using MVC_ModeloPrimerParcialMiercoles15Mayo.Entidades;
using MVC_ModeloPrimerParcialMiercoles15Mayo.Logica;

namespace MVC_ModeloPrimerParcialMiercoles15Mayo.Controllers
{
    public class BarcosController : Controller
    {
        private IBarcoService _barcoService;

        public BarcosController(IBarcoService barcoService) { 
            this._barcoService = barcoService;
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarPOST(Barco barco)
        {
            if (!ModelState.IsValid) {
                return View("Registrar", barco);
            }
            _barcoService.RegistrarBarco(barco);
            return RedirectToAction("Listado");
        }


        public IActionResult Listado()
        {
            List<Barco> listaBarcos =  _barcoService.ObtenerListaDeBarcos();    
            return View(listaBarcos);
        }
    }
}
