using Microsoft.AspNetCore.Mvc;
using RelacionesEntityFramework.Data.Entidades;
using RelacionesEntityFramework.Logica;

namespace RelacionesEntityFramework.Controllers
{
    public class JugadorController : Controller
    {
        private readonly ISeleccionLogica _seleccionLogica;
        private readonly IJugadorLogica _jugadorLogica;
        public JugadorController(ISeleccionLogica seleccionLogica, IJugadorLogica jugadorLogica)
        {
            this._seleccionLogica = seleccionLogica;
            this._jugadorLogica = jugadorLogica;
        }


        public async Task<IActionResult> Index()
        {
            var jugadores = await _jugadorLogica.ObtenerTodosJugadores();
            return View(jugadores);
        }

        public async Task<IActionResult> VerJugadorPorSeleccion(int idSeleccion)
        {
            var jugadores = await _jugadorLogica.ObtenerTodosJugadoresPorSeleccion(idSeleccion);
            return View("Index",jugadores);
        }

        public async Task<IActionResult> Agregar() {
            ViewBag.Selecciones = await _seleccionLogica.ObtenerTodasAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(Jugador jugador)
        {
            if (!ModelState.IsValid)
            {
                return View(jugador);
            }
            await _jugadorLogica.GuardarJugador(jugador);
            return RedirectToAction("Index");
        }
    }
}
