using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RelacionesEntityFramework.Data.Entidades;

public class JugadorModelMetaData
{
    [Required(ErrorMessage = "Es obligatorio este campo")]
    [StringLength(maximumLength: 20, ErrorMessage ="El campo debe tener un maximo de 20 caracteres")]
    public string? Apellido { get; set; }

    [Required(ErrorMessage = "Es obligatorio este campo")]
    [StringLength(maximumLength: 20, ErrorMessage = "El campo debe tener un maximo de 20 caracteres")]
    public string? Nombre { get; set; }
}


[ModelMetadataType(typeof(JugadorModelMetaData))]
public partial class Jugador
{
    public int IdJugador { get; set; }

    public string? Apellido { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public byte? PiernaHabil { get; set; }

    public int? IdSeleccion { get; set; }

    public virtual Seleccion? IdSeleccionNavigation { get; set; }
}
