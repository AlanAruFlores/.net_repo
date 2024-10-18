using System;
using System.Collections.Generic;

namespace RelacionesEntityFramework.Data.Entidades;

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
