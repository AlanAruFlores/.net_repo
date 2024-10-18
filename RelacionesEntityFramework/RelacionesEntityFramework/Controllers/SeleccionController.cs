using Microsoft.AspNetCore.Mvc;
using RelacionesEntityFramework.Data.Entidades;
using RelacionesEntityFramework.Logica;

namespace RelacionesEntityFramework.Controllers
{
    public class SeleccionController : Controller
    {
        private readonly ISeleccionLogica _seleccionLogica;
        private readonly IJugadorLogica _jugadorLogica;
        public SeleccionController(ISeleccionLogica seleccionLogica, IJugadorLogica jugadorLogica) { 
            this._seleccionLogica = seleccionLogica;
            this._jugadorLogica = jugadorLogica;
        }

        public async Task<IActionResult> Index()
        {
            var selecciones = await _seleccionLogica.ObtenerTodasAsync();
            return View(selecciones);
        }


        public IActionResult Agregar() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(Seleccion seleccion) { 
            if(!ModelState.IsValid)
                return View(seleccion);

            await _seleccionLogica.AgregarAsync(seleccion);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> IncorporarJugador(int idSeleccion) {
            ViewBag.Jugadores = await _jugadorLogica.ObtenerTodosJugadores();
            var seleccion  =await _seleccionLogica.ObtenerPorId(idSeleccion);
            ViewBag.NombreSeleccion = seleccion.Nombre;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> IncorporarJugador(int idSeleccion, int idJugador) {
            var jugador = await _jugadorLogica.ModificarJugador(idSeleccion, idJugador);
            return View();
        }
    }
}
