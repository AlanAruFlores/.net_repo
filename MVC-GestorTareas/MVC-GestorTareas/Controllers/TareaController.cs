using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_GestorTareas.Entidades;
using MVC_GestorTareas.Logica;
using MVC_GestorTareas.Models;
using System.Diagnostics;

namespace MVC_GestorTareas.Controllers
{
    public class TareaController : Controller
    {
        private readonly ILogger<TareaController> _logger;
        public ITareaService _tareaService;

        public TareaController(ILogger<TareaController> logger, ITareaService tareaService)
        {
            _logger = logger;
            _tareaService = tareaService;
        }

        public IActionResult Index()
        {
            List<Tarea> tareas = _tareaService.ObtenerTareasNoCompletadas();
            _logger.LogWarning("Cantidad: "+tareas.Count);
            return View(tareas);
        }

        public IActionResult Agregar() {
            return View();
        }

        public IActionResult Eliminar(int id)
        {
            _tareaService.Eliminar(id);
            return RedirectToAction("Index");
        }

        public IActionResult ListarTarea(int id) {
            _tareaService.ListarCompletada(id);
            return RedirectToAction("VerCompletadas");
        }

        public IActionResult VerCompletadas()
        {
            List<Tarea> tareas = _tareaService.ObtenerTareasCompletadas();
            return View(tareas);
        }

        [HttpPost]
        public IActionResult AgregarPOST(Tarea tarea)
        {
            if (!ModelState.IsValid) { 
                return View("Agregar",tarea);
            }
            _tareaService.GuardarTarea(tarea);
            return RedirectToAction("Index");
        }

        public IActionResult DescartarCompletada(int id) {
            _tareaService.DescartarComoCompletada(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
