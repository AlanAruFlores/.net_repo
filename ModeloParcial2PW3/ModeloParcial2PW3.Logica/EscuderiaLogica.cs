using Microsoft.EntityFrameworkCore;
using ModeloParcial2PW3.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial2PW3.Logica
{

    public interface IEscuderiaLogica {
        Task<IEnumerable<Escuderium>> GetAllEscuderias();
    }
    public class EscuderiaLogica : IEscuderiaLogica
    {
        private readonly Formula1Context _context;

        public EscuderiaLogica(Formula1Context context) { 
            _context = context;
        }

        public async Task<IEnumerable<Escuderium>> GetAllEscuderias()
        {
            return await _context.Escuderia.ToListAsync();
        }
    }
}
