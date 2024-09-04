using Microsoft.AspNetCore.Mvc;
using MVCApplication.Entidad;
using MVCApplication.Logica;

namespace MVCApplication.Controllers
{
    public class RegaloController : Controller
    {
        private IRegaloLogica _regaloLogica;

        public RegaloController(IRegaloLogica regaloLogica)
        {
            _regaloLogica = regaloLogica;
        }


        public IActionResult Index()
        {
            return View(_regaloLogica.GetRegalos());
        }


        [HttpGet]
        public IActionResult Agregar() {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Regalo regalo)
        {
            this._regaloLogica.AgregarRegalo(regalo);
            return RedirectToAction("Index");
        }
    }
}
