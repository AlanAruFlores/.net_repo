using Microsoft.EntityFrameworkCore;
using ModeloParcial2PW3.Entidades.Entidades;

namespace ModeloParcial2PW3.Logica
{
    public interface IPilotoLogica { 
        Task AgregarPiloto(Piloto piloto);
        Task EliminarPiloto(int id);
        Task<IEnumerable<Piloto>> GetAllPilotos();
        Task<IEnumerable<Piloto>> GetAllPilotosNoEliminados();
        Task<IEnumerable<Piloto>> GetAllPilotosPorEscuderia(Escuderium escuderium);
    }

    public class PilotoLogica : IPilotoLogica
    {
        private readonly Formula1Context _context;

        public PilotoLogica(Formula1Context context) { 
            _context = context;
        }

        public async Task AgregarPiloto(Piloto piloto)
        {
            piloto.Eliminado = false;
            _context.Pilotos.Add(piloto);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarPiloto(int id)
        {
            Piloto piloto = await _context.Pilotos.FirstAsync(p => p.IdPiloto == id);
            piloto.Eliminado = true;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Piloto>> GetAllPilotos() {
            return await _context.Pilotos.Include(p=>p.IdEscuderiaNavigation).ToListAsync();
        }

        public async Task<IEnumerable<Piloto>> GetAllPilotosNoEliminados()
        {
            return await _context.Pilotos.Include(p => p.IdEscuderiaNavigation).Where(p=>p.Eliminado == false).ToListAsync();
        }

        public async Task<IEnumerable<Piloto>> GetAllPilotosPorEscuderia(Escuderium escuderium)
        {
            return await _context.Pilotos.Include(p => p.IdEscuderiaNavigation).Where(p => p.Eliminado == false && p.IdEscuderiaNavigation.NombreEscuderia == escuderium.NombreEscuderia).ToListAsync();
        }
    }
}
