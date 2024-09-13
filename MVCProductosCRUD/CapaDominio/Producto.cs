using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class Producto
    {


        public int ID { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "La descripción debe tener entre 10 y 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Debe ser un precio positivo")]
        public decimal Precio { get; set; }
        
        [Required(ErrorMessage = "El stock del producto es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ser un numero positivo")]
        public int Stock { get; set; }
    
    }
}
