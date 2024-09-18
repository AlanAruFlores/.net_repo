using System.ComponentModel.DataAnnotations;

namespace MVC_PracticaParcialUno.Models
{
    public class CalculadoraViewModel
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Range(0,100,ErrorMessage ="Debe estar entre rango de 0-100")]
        public int NumeroUno { get; set; }


        [Required(ErrorMessage = "Campo Obligatorio")]
        [Range(0, 100, ErrorMessage = "Debe estar entre rango de 0-100")] 
        public int NumeroDos { get; set; }
    }
}
