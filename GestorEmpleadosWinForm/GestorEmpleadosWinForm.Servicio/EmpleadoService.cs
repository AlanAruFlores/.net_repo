using GestorEmpleadosWinForm.Entidad;

namespace GestorEmpleadosWinForm.Servicio
{
    public interface IEmpleadoService
    {
        void Guardar(Empleado empleado);
        bool Eliminar(int dni);
        List<Empleado> GetEmpleados();
    }

    public class EmpleadoService:IEmpleadoService
    {

        private static List<Empleado> dataEmpleados = new List<Empleado> { 
            new Empleado(24424, "Pedro", 24, 2000),
            new Empleado(21334, "Ale", 44, 1000),
            new Empleado(12345, "Martin", 22, 3000),
            new Empleado(12334, "Carlos", 50, 4000)
        };

        public List<Empleado> GetEmpleados()
        {
            return dataEmpleados;
        }

        public void Guardar(Empleado empleado)
        {
            dataEmpleados.Add(empleado);
        }

        public bool Eliminar(int id)
        {
            Empleado em = GetEmpleadoID(id);
            if (em == null)
                return false;

            dataEmpleados.Remove(em);
            return true;
        }

        public Empleado GetEmpleadoID(int id)
        {
            return dataEmpleados.Find(em => em.DNI == id);
        }
    }
}
