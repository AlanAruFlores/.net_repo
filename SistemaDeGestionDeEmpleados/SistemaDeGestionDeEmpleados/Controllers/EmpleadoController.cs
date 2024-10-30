using Microsoft.AspNetCore.Mvc;
using SistemaDeGestionDeEmpleados.Data.Entidades;
using SistemaDeGestionDeEmpleados.Servicios;

namespace SistemaDeGestionDeEmpleados.Web.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoServicio _empleadoServicio;
        private readonly ISucursalServicio _sucursalServicio;

        public EmpleadoController(IEmpleadoServicio empleadoServicio, ISucursalServicio sucursalServicio)
        {
            _empleadoServicio = empleadoServicio;
            _sucursalServicio = sucursalServicio;
        }

        public async Task<IActionResult> Index(int? IdSucursal)
        {
            List<Empleado> empleados = IdSucursal.HasValue ?  
                await _empleadoServicio.ObtenerEmpleadosPorSucursal((int)IdSucursal)
                : await _empleadoServicio.ObtenerTodosEmpleados();

            //Lista de sucursales para poder filtrar
            ViewBag.Sucursales = await _sucursalServicio.ObtenerSucursalesNoEliminadasOrdenadas();
            ViewBag.IdSucursalSeleccionada = IdSucursal;

            return View(empleados);
        }

        public async Task<IActionResult> Agregar() {
            List <Sucursal> sucursales= await _sucursalServicio.ObtenerSucursalesNoEliminadasOrdenadas();
            ViewBag.Sucursales=sucursales;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(Empleado empleado)
        {
            await _empleadoServicio.GuardarEmpleado(empleado);
            return RedirectToAction("Index");
        }

    }
}
