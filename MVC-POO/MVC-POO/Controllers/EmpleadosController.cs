using Microsoft.AspNetCore.Mvc;
using MVC_POO.Entidades;
using MVC_POO.Logica;
using MVC_POO.Models;

namespace MVC_POO.Controllers
{
    public class EmpleadosController : Controller
    {
        public IEmpleadoLogica _empleadoService;
        public IContractorsLogica _contractorService;

        public EmpleadosController(IEmpleadoLogica empleadoService,IContractorsLogica contractorService)
        {
            _empleadoService = empleadoService;
            _contractorService = contractorService;
        }

        public IActionResult Index()
        {
            List<Empleado> empleados = _empleadoService.ObtenerTodos();
            List<Contratado> contratados = _contractorService.ObtenerTodos();


            var total = LiquidadorSueldos<Empleado>.CalcularSueldosTotalEmpleado(empleados);
            total += LiquidadorSueldos<Contratado>.CalcularSueldosTotalEmpleado(contratados);

            EmpleadosModelView emv = new EmpleadosModelView()
            {
                Empleados = empleados,
                Contratados = contratados
            };

            ViewBag.SueldoALiquidar = total;
            return View(emv);
        }

        [HttpGet]
        public IActionResult LiquidarSueldos() {
            return View();
        }

        [HttpPost]
        public IActionResult LiquidarSueldosPost()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AgregarEmpleadoPasante() {
            return View();
        }



        [HttpPost]
        public IActionResult AgregarEmpleadoPasantePost(Pasante pasante)
        {

            _empleadoService.Agregar(pasante);
            return RedirectToAction("Index");
        }
    }
}
