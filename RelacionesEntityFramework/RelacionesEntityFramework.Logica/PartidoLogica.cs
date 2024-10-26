using Microsoft.EntityFrameworkCore;
using RelacionesEntityFramework.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelacionesEntityFramework.Logica
{

    public interface IPartidoLogica {
        Task AgregarPartidoNuevo(Partido partido);
        Task<List<Partido>> ObtenerTodosLosPartidos();
     }

    public class PartidoLogica : IPartidoLogica
    {
        private readonly EliminatoriasDbContext _context;

        public PartidoLogica(EliminatoriasDbContext context)
        {
            _context = context;
        }


        public async Task AgregarPartidoNuevo(Partido partido)
        {
            _context.Partidos.Add(partido);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Partido>> ObtenerTodosLosPartidos() {
            return await _context.Partidos.Include(p=>p.Local).Include(p=>p.Visitante).ToListAsync();
        }
    }
}
