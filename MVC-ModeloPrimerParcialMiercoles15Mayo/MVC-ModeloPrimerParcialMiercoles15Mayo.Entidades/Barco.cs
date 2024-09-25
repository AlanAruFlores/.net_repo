using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_ModeloPrimerParcialMiercoles15Mayo.Entidades
{
    public class Barco
    {

        public int IdBarco { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "Maximo 20 caracteres")]
        public string Nombre { get; set; }

        [DisplayName("Antiguedad")]
        [Required(ErrorMessage = "Campo Requerido")]
        [Range(0, 200, ErrorMessage = "La cantidad debe ser mayor a 0 y menor a 200")]
        public int Antiguedad { get; set; }


        [DisplayName("Tripulacion Maxima")]
        [Required(ErrorMessage = "Campo Requerido")]
        [Range(0, 500, ErrorMessage = "El precio unitario debe ser mayor o igual a 1 y menor a 500")]
        public int TripulacionMaxima { get; set; }

        public int Tasa { get; set;}
    }
}
