using System;
using System.Collections.Generic;

namespace SistemaDeGestionDeEmpleados.Data.Entidades;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? NombreCompleto { get; set; }

    public int? IdSucursal { get; set; }

    public virtual Sucursal? IdSucursalNavigation { get; set; }
}
