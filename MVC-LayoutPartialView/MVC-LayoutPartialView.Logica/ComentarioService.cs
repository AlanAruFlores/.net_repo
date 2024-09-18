using MVC_LayoutPartialView.Entidades;

namespace MVC_LayoutPartialView.Logica
{

    public interface IComentarioService {
        void AgregarComentario(Comentario comentario);

        List<Comentario> ObtenerComentarios();
    }

    public class ComentarioService : IComentarioService
    {
        private static List<Comentario> comentarios = new List<Comentario>();

        public void AgregarComentario(Comentario comentario)
        {
            comentario.ComentarioId = (comentarios.Count == 0) ? 1 : comentarios.Max(c => c.ComentarioId) + 1;
            comentarios.Add(comentario);
        }

        public List<Comentario> ObtenerComentarios()
            => comentarios.OrderByDescending(c => c.ComentarioId).ToList();
       
        
    }
}
