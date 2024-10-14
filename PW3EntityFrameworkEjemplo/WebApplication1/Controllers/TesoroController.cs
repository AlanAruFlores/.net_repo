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
        
        [HttpGet("{id}")]
        public Tesoro GetTesoroById(int id) {
            return _tesoroServicio.ObtenerTesoroPorId(id);
        }

        [HttpPost]
        public void PostTesoro([FromBody]Tesoro tesoro) {
            _tesoroServicio.AgregarTesoro(tesoro);
        }

        [HttpPut("{id}")]
        public void UpdateTesoro(int id, [FromBody]Tesoro tesoro) 
        {
            tesoro.Id = id;
            _tesoroServicio.ActualizarTesoro(tesoro);
        }
        [HttpDelete("{id}")]
        public void DeleteTesoro(int id)
        {
            _tesoroServicio.EliminarTesoro(id);
        }
    }
}
