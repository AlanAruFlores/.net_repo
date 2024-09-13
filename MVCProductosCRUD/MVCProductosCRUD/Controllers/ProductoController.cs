using CapaDominio;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;
using MVCProductosCRUD.Models;
using System.Diagnostics;

namespace MVCProductosCRUD.Controllers
{
    public class ProductoController : Controller {

        IProductoService _productoService;
        public ProductoController(IProductoService productoService)
        {
            this._productoService = productoService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<Producto> productos = _productoService.ObtenerLosProductos();
            return View(productos);
        }

        [HttpGet]
        public IActionResult Guardar() { 
            return View();
        }



        [HttpPost]
        public IActionResult GuardarNuevo(Producto producto)
        {
            if (ModelState.IsValid) {
                _productoService.CrearProducto(producto);
                return RedirectToAction("Index");
            }

            return View("Guardar",producto);
        }


        [HttpGet]
        public IActionResult Eliminar (int id)
        {
            _productoService.EliminarProductoPorId(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Actualizar(int id)
        {
            Producto producto = _productoService.ObtenerProductoId(id);
            return View("Actualizar", producto);
        }

        [HttpPost]
        public IActionResult ActualizarProducto(Producto producto)
        {

            if (ModelState.IsValid)
            {
                _productoService.ActualizarProducto(producto);
                return RedirectToAction("Index");
            }
            return View("Actualizar", producto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
