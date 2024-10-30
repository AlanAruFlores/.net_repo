using System;
using System.Collections.Generic;

namespace SistemaDeGestionDeEmpleados.Data.Entidades;

public partial class Sucursal
{
    public int IdSucursal { get; set; }

    public string? Direccion { get; set; }

    public bool? Eliminada { get; set; }

    public string? Nombre { get; set; }

    public string? Ciudad { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
