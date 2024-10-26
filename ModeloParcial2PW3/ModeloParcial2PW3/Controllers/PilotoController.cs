using Microsoft.AspNetCore.Mvc;
using ModeloParcial2PW3.Entidades.Entidades;
using ModeloParcial2PW3.Logica;

namespace ModeloParcial2PW3.Controllers
{
    public class PilotoController : Controller
    {
        private readonly IPilotoLogica _pilotoLogica;
        private readonly IEscuderiaLogica _escuderiaLogica;

        public PilotoController(IPilotoLogica pilotoLogica, IEscuderiaLogica escuderiaLogica) {
            _pilotoLogica = pilotoLogica;
            _escuderiaLogica = escuderiaLogica;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<Piloto> pilotos = await _pilotoLogica.GetAllPilotosNoEliminados();
            List<Escuderium> escuderias = (List<Escuderium>)await _escuderiaLogica.GetAllEscuderias();
            ViewBag.Pilotos = pilotos;
            ViewBag.Escuderias = escuderias;
            return View();
        }

        public async Task<IActionResult> FitrarEscuderia(Escuderium escuderium)
        {
            IEnumerable<Piloto> pilotos = await _pilotoLogica.GetAllPilotosPorEscuderia(escuderium);
            List<Escuderium> escuderias = (List<Escuderium>)await _escuderiaLogica.GetAllEscuderias();
            ViewBag.Escuderias = escuderias;
            ViewBag.Pilotos = pilotos;
            return View("Index");
        }


        public async Task<IActionResult> Agregar() {
            List<Escuderium> escuderias = (List<Escuderium>) await _escuderiaLogica.GetAllEscuderias();
            ViewBag.Escuderias = escuderias;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Agregar(Piloto piloto)
        {
            await _pilotoLogica.AgregarPiloto(piloto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            await _pilotoLogica.EliminarPiloto(id);
            return RedirectToAction("Index");
        }
    }
}
