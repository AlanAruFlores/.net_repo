using System.ComponentModel.DataAnnotations;

namespace MVC_GestorTareas.Entidades
{
    public class Tarea
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Este campo es obligatorio")]
        [StringLength(maximumLength:15, ErrorMessage = "Debe tener un maximo de 20 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
