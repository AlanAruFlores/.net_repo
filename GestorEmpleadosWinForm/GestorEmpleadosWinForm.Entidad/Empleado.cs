namespace GestorEmpleadosWinForm.Entidad
{
    public class Empleado
    {
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public double Sueldo { get; set; }

        public Empleado(int dNI, string nombre, int edad, double sueldo)
        {
            DNI = dNI;
            Nombre = nombre;
            Edad = edad;
            Sueldo = sueldo;
        }
    }
}
