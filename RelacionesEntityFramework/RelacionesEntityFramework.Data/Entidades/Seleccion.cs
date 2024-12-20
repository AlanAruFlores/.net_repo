﻿using System;
using System.Collections.Generic;

namespace RelacionesEntityFramework.Data.Entidades;

public partial class Seleccion
{
    public int IdSeleccion { get; set; }

    public string? Nombre { get; set; }

    public string? Escudo { get; set; }

    public virtual ICollection<Jugador> Jugadors { get; set; } = new List<Jugador>();

    public virtual ICollection<Partido> PartidoLocals { get; set; } = new List<Partido>();

    public virtual ICollection<Partido> PartidoVisitantes { get; set; } = new List<Partido>();
}
