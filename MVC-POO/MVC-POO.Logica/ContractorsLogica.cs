using MVC_POO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_POO.Logica
{
    public interface IContractorsLogica
    {
        public List<Contratado> ObtenerTodos();
        public void Agregar(Contratado emp);
    }

    public class ContractorsLogica : IContractorsLogica
    {
        private List<Contratado> _empleados = new List<Contratado>();
        public void Agregar(Contratado emp)
        {
            _empleados.Add(emp);
        }

        public List<Contratado> ObtenerTodos()
        {
            return _empleados;
        }
    }
}
