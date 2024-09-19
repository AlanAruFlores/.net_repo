using System.ComponentModel.DataAnnotations;

namespace MVC_ModeloParcialMiercoles11Mayo.Entidades
{
    public class Venta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(maximumLength:50, ErrorMessage = "La longitud maxima es de 50 caracteres")]
        public String Cliente { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(1,300, ErrorMessage ="Debe ser un numero entre 1-300") ]
        public int CantidadVendida { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(10,1000, ErrorMessage = "Debe ser un numero entre 1-1000")]
        public int PrecioUnitario { get; set; }
    }
}
