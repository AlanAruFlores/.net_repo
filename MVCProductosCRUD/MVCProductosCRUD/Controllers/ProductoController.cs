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

        public IActionResult Index()
        {
            List<Producto> productos = _productoService.ObtenerLosProductos();
            Console.WriteLine("Productos: "+productos.Count());
            return View(productos);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
