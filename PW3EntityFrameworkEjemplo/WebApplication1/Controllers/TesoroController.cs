using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PW3EntityFrameworkEjemplo.Data.Entidades;
using PW3EntityFrameworkEjemplo.Logica;

namespace PW3EntityFrameworkEjemploWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesoroController : ControllerBase
    {
        private ITesoroServicio _tesoroServicio;

        public TesoroController(ITesoroServicio tesoroServicio) { 
            this._tesoroServicio = tesoroServicio;
        }
            
        [HttpGet]
        public List<Tesoro> GetAllTesoros() { 
            return _tesoroServicio.ObtenerTodosLosTesoros();
        }
    }
}
