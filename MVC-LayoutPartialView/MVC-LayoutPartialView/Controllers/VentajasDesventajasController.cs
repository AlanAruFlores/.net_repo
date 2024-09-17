using Microsoft.AspNetCore.Mvc;
using MVC_LayoutPartialView.Entidades;
using MVC_LayoutPartialView.Logica;
using MVC_LayoutPartialView.Models;

namespace MVC_LayoutPartialView.Controllers
{
    public class VentajasDesventajasController : Controller
    {
        private IComentarioService _comentarioService;
        private ILogger _logger;


        public VentajasDesventajasController (IComentarioService comentarioService, ILogger<VentajasDesventajasController> logger)
        {
            this._comentarioService = comentarioService;
            this._logger  = logger; 
        }

        public IActionResult PanelesSolares()
        {
            _logger.LogWarning("Cantidad Registros: "+ComentarioModelView.GetLista(_comentarioService.ObtenerComentarios()).Count);
            ViewBag.Comentarios = ComentarioModelView.GetLista(_comentarioService.ObtenerComentarios());
          
            return View();
        }

        [HttpPost]
        public IActionResult PanelSolaresComentar(ComentarioModelView mv)
        {

            if (!ModelState.IsValid)
            {
                return View("PanelesSolares", mv);
            }

            _comentarioService.AgregarComentario(new Comentario{
                ComentarioText = mv.CommentText
            });
            
            return RedirectToAction("PanelesSolares");
        }
    }
}
