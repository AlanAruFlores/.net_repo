using Microsoft.EntityFrameworkCore;
using SistemaDeGestionDeEmpleados.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionDeEmpleados.Servicios
{
    public interface IEmpleadoServicio
    {
        Task<Empleado> GuardarEmpleado(Empleado empleado);
        Task<List<Empleado>> ObtenerTodosEmpleados();

        Task<List<Empleado>> ObtenerEmpleadosPorSucursal(int idSucursal);

    }

    public class EmpleadoServicio : IEmpleadoServicio
    {

        private readonly ModeloPw3Context _context;

        public EmpleadoServicio(ModeloPw3Context context) {
            _context = context;
        }

        public async Task<Empleado> GuardarEmpleado(Empleado empleado)
        {
            await _context.Empleados.AddAsync(empleado);
            await _context.SaveChangesAsync();
            return empleado;
        }

        public async Task<List<Empleado>> ObtenerEmpleadosPorSucursal(int idSucursal)
        {
            return await _context.Empleados
                .Include(em => em.IdSucursalNavigation)
                .Where(em=> em.IdSucursal == idSucursal)
                .ToListAsync();
        }

        public async Task<List<Empleado>> ObtenerTodosEmpleados()
        {
            return await _context.Empleados.Include(em=>em.IdSucursalNavigation).ToListAsync();
        }
    }
}
