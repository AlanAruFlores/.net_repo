using MVC_GestorTareas.Entidades;

namespace MVC_GestorTareas.Logica
{
    public interface ITareaService
    {
        public List<Tarea> ObtenerTareasNoCompletadas();
        public List<Tarea> ObtenerTareasCompletadas();
        public void GuardarTarea(Tarea t);
        void Eliminar(int id);
        void ListarCompletada(int id);
        void DescartarComoCompletada(int id);

    }

    public class TareaService : ITareaService
    {
        static List<Tarea> tareas = new List<Tarea>();

        public void GuardarTarea(Tarea t)
        {
            t.Id = (tareas.Count != 0) ? tareas.Max(a=>a.Id)+1 : 1;
            t.Estado = false;
            tareas.Add(t);
        }

        public List<Tarea> ObtenerTareasNoCompletadas()
        {
            return tareas.Where(t=> t.Estado == false).ToList();
        }

        public List<Tarea> ObtenerTareasCompletadas()
        {
            return tareas.Where(t => t.Estado == true).ToList();
        }


        public void Eliminar(int id)
        {
            tareas = tareas.Where(a => a.Id != id).ToList();
        }

        public void ListarCompletada(int id)
        {
            Tarea tarea  = tareas.TakeWhile(a => a.Id == id).First();
            tarea.Estado = true;
        }

        public void DescartarComoCompletada(int id)
        {
            Tarea tarea = tareas.TakeWhile(a => a.Id == id).First();
            tarea.Estado = false;
        }
    }
}
