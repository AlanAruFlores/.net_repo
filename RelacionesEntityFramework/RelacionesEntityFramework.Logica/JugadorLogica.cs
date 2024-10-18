using Microsoft.EntityFrameworkCore;
using RelacionesEntityFramework.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelacionesEntityFramework.Logica
{

    public interface IJugadorLogica
    {
        public Task<Jugador> GuardarJugador(Jugador jugador);
        public Task<Jugador> ObtenerPorId(int idJugador);
        public Task<Jugador> ModificarJugador(int idSeleccion, int idJugador);
        public Task<IEnumerable<Jugador>> ObtenerTodosJugadores();

        public Task<IEnumerable<Jugador>> ObtenerTodosJugadoresPorSeleccion(int idSeleccion);

    }
    public class JugadorLogica : IJugadorLogica
    {
        private EliminatoriasDbContext _context;

        public JugadorLogica(EliminatoriasDbContext context)
        {
            _context = context;
        }

        public async Task<Jugador> GuardarJugador(Jugador jugador)
        {
            _context.Jugadors.Add(jugador);
            await _context.SaveChangesAsync();
            return jugador;
        }

        public async Task<Jugador> ModificarJugador(int idSeleccion, int idJugador)
        {
            var jugador = await ObtenerPorId(idJugador);
            jugador.IdSeleccion = idSeleccion;

            await _context.SaveChangesAsync();
            return jugador;
        }

        public async Task<Jugador> ObtenerPorId(int idJugador)
        {
            return await _context.Jugadors.Include(j => j.IdSeleccionNavigation).FirstAsync(j => j.IdJugador == idJugador);
        }

        public async Task<IEnumerable<Jugador>> ObtenerTodosJugadores()
        {
            return await _context.Jugadors.Include(j => j.IdSeleccionNavigation)
                .OrderBy(j => j.Apellido) // Ordenar por apellido
                .ThenBy(j => j.Nombre) // si tiene el mismo apellido , entonces por nombre
                .ToListAsync();
        }

        public async Task<IEnumerable<Jugador>> ObtenerTodosJugadoresPorSeleccion(int idSeleccion)
        {
            return await _context.Jugadors.Include(j => j.IdSeleccionNavigation)
                .Where(j => j.IdSeleccion == idSeleccion)
                .OrderBy(j => j.Apellido) // Ordenar por apellido
                .ThenBy(j => j.Nombre) // si tiene el mismo apellido , entonces por nombre
                .ToListAsync();
        }
    }
}
