using System.Reflection.Metadata.Ecma335;

namespace MVC_POO.Entidades
{

    public interface ICalcularSueldo { 
        public int CalcularSueldo();
    }

    public class Empleado:ICalcularSueldo
    {
        public string Nombre { get; set; }
        public int SueldoBase { get; set; }
        public int Antiguedad { get; set; }
        public int HorasExtras { get; set; }

        public virtual int CalcularSueldo() => SueldoBase + (Antiguedad * 100) + (HorasExtras*200);
        
    }
}
