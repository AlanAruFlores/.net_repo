namespace MVCApplication.Entidad
{
    public class Regalo
    {
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Imagen { get; set; }

        public Regalo() { }
        public Regalo(string descripcion, double precio, string imagen = "/images/default.jpg")
        {
            Descripcion = descripcion;
            Precio = precio;
            Imagen = imagen;
        }
    }
}
