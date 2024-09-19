using Microsoft.AspNetCore.Mvc;
using MVC_ModeloParcialMiercoles11Mayo.Entidades;
using MVC_ModeloParcialMiercoles11Mayo.Logica;
using MVC_ModeloParcialMiercoles11Mayo.Models;

namespace MVC_ModeloParcialMiercoles11Mayo.Controllers
{
    public class VentaController : Controller
    {
        private IVentaService _ventaService;

        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        public IActionResult RegistrarVenta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarVentaPOST(Venta venta)
        {
            if (!ModelState.IsValid) {
                return View("RegistrarVenta", venta);
            }

            _ventaService.Guardar(venta);
            return RedirectToAction("Resultados");
        }


        public IActionResult Resultados()
        {
            List<Venta> ventas = _ventaService.ObtenerVentas();
            List<VentaViewModel> _ventasVM = VentaViewModel.FromVentaToVentaViewModel(ventas);
            return View(_ventasVM);
        }
    }
}
