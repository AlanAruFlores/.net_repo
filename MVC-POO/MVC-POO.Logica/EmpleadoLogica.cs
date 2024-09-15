using MVC_POO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_POO.Logica
{

    public interface IEmpleadoLogica
    {
        public List<Empleado> ObtenerTodos();
        public void Agregar(Empleado emp);
    }

    public class EmpleadoLogica : IEmpleadoLogica
    {
        private List<Empleado> _empleados = new List<Empleado>();
        public void Agregar(Empleado emp)
        {
            _empleados.Add(emp);
        }

        public List<Empleado> ObtenerTodos()
        {
            return _empleados;
        }
    }
}
