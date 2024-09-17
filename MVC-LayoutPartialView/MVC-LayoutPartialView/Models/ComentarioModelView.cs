using MVC_LayoutPartialView.Entidades;
using System.ComponentModel.DataAnnotations;

namespace MVC_LayoutPartialView.Models
{
    public class ComentarioModelView
    {
        public string AvatarUrl { get; set; }
        public string ProfileUrl { get;set; }

        [StringLength(10, ErrorMessage="No puede tener mas de 10 caracteres")]
        public string CommentText { get; set; }

        public string ViewMoreLink { get; set; }


        public static List<ComentarioModelView> GetLista(List<Comentario> comentarios)
        {
            List<ComentarioModelView> lista = new List<ComentarioModelView>();
        
            comentarios.ForEach(com => lista.Add(new ComentarioModelView { 
                AvatarUrl = "http://example.com",    
                CommentText = com.ComentarioText,
                ProfileUrl = "http://example.com",
                ViewMoreLink = "http://example.com"
            }));


            return lista;
        }
    }
}
