using Microsoft.EntityFrameworkCore;
using SistemaDeGestionDeEmpleados.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionDeEmpleados.Servicios
{
    public interface ISucursalServicio {
        Task<List<Sucursal>> ObtenerSucursalesNoEliminadasOrdenadas();
    }

    public class SucursalServicio : ISucursalServicio
    {
        private readonly ModeloPw3Context _context;

        public SucursalServicio(ModeloPw3Context context)
        {
            _context = context;
        }

        public async Task<List<Sucursal>> ObtenerSucursalesNoEliminadasOrdenadas()
        {
            return await _context.Sucursals
                .Where(s=>s.Eliminada != true)
                .OrderBy(s=>s.Direccion) //Ordena de la A-Z
                .ToListAsync();
        }
    }
}
