using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RelacionesEntityFramework.Data.Entidades;

public class PartidoModelData {

    [Required(ErrorMessage = "Campo Obligatorio")]
    public int? VisitanteId { get; set; }
    
    [Required(ErrorMessage = "Campo Obligatorio")]
    public int? LocalId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public int? GolesVisitante { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public int? GolesLocal { get; set; }
    
    [Required(ErrorMessage = "Campo Obligatorio")]
    public string? Estadio { get; set; }

}

[ModelMetadataType(typeof(PartidoModelData))]
public partial class Partido
{
    public int Id { get; set; }

    public int? VisitanteId { get; set; }

    public int? LocalId { get; set; }

    public int? GolesVisitante { get; set; }

    public int? GolesLocal { get; set; }

    public string? Estadio { get; set; }

    public virtual Seleccion? Local { get; set; }

    public virtual Seleccion? Visitante { get; set; }
}
