using Microsoft.EntityFrameworkCore;
using RelacionesEntityFramework.Data.Entidades;

namespace RelacionesEntityFramework.Logica
{
    public interface ISeleccionLogica
    {
        Task<IEnumerable<Seleccion>> ObtenerTodasAsync();
        Task<Seleccion> AgregarAsync(Seleccion seleccion);
        Task<Seleccion> ObtenerPorId(int idSeleccion);
    }

    public class SeleccionLogica : ISeleccionLogica
    {
        private EliminatoriasDbContext _context;
        public SeleccionLogica(EliminatoriasDbContext dbContext) { 
            this._context = dbContext;
        }

        public async Task<Seleccion> AgregarAsync(Seleccion seleccion)
        {
            _context.Seleccions.Add(seleccion); 
            await _context.SaveChangesAsync();
            return seleccion;
        }

        public async Task<Seleccion> ObtenerPorId(int idSeleccion)
        {
            return await _context.Seleccions.FindAsync(idSeleccion);
        }


        //Tareas asincronas y permite que el hilo principal no se bloquee 
        public async Task<IEnumerable<Seleccion>> ObtenerTodasAsync()
        {
            return await _context.Seleccions.ToListAsync();
        }
    }
}
