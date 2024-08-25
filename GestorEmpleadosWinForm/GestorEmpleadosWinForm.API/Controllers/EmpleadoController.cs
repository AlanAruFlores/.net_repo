using GestorEmpleadosWinForm.Entidad;
using GestorEmpleadosWinForm.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorEmpleadosWinForm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {

        IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet("GetAllEmpleados")]
        public IActionResult GetAllEmpleados() {
            return Ok(_empleadoService.GetEmpleados());
        }

        [HttpPost("PostNewEmpleado")]
        public IActionResult PostNewEmpleado([FromBody] Empleado empleado) { 
            _empleadoService.Guardar(empleado);
            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
