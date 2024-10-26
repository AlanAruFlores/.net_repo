using Microsoft.AspNetCore.Mvc;
using RelacionesEntityFramework.Data.Entidades;
using RelacionesEntityFramework.Logica;

namespace RelacionesEntityFramework.Controllers
{
    public class PartidoController : Controller
    {
        private readonly IPartidoLogica _partidoLogica;
        private readonly ISeleccionLogica _seleccionLogica;

        public PartidoController(IPartidoLogica partidoLogica, ISeleccionLogica seleccionLogica)
        {
            _partidoLogica = partidoLogica;
            _seleccionLogica = seleccionLogica;

        }


        public async Task<IActionResult> Index()
        {
            List<Partido> _partidos = await _partidoLogica.ObtenerTodosLosPartidos();
            return View(_partidos);
        }


        public async Task <IActionResult> Agregar() {
            IEnumerable<Seleccion> _selecciones = await _seleccionLogica.ObtenerTodasAsync();
            ViewBag.Selecciones = _selecciones;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Agregar(Partido partido) {
            if (!ModelState.IsValid)
            {
                IEnumerable<Seleccion> _selecciones = await _seleccionLogica.ObtenerTodasAsync();
                ViewBag.Selecciones = _selecciones;
                return View(partido);
            }
            await _partidoLogica.AgregarPartidoNuevo(partido);
            return RedirectToAction("Index");
        }
    }
}
