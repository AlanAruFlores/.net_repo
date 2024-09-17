using Microsoft.AspNetCore.Mvc;
using MVC_LayoutPartialView.Models;

namespace MVC_LayoutPartialView.Controllers
{
    public class VentajasDesventajasController : Controller
    {
        public IActionResult PanelesSolares()
        {
            var comentarios = new List<ComentarioModelView> {
                new ComentarioModelView{ 
                    AvatarUrl = "https://avatarfiles.alphacoders.com/366/366077.png",
                    ProfileUrl = "https://twitter.com/usuario1",
                    CommentText = "Este es el primer comentario",
                    ViewMoreLink = "https://example.com/ver-mas-1",
                },
                new ComentarioModelView{
                    AvatarUrl = "https://i.pinimg.com/736x/68/84/10/688410c12edecf385116ef28b769e257.jpg",
                    ProfileUrl = "https://twitter.com/usuario2",
                    CommentText = "Segundo comentario ¡Muy Interesante!",
                    ViewMoreLink = "https://example.com/ver-mas-2",
                }

            };

            ViewBag.Comentarios = comentarios;
            return View();
        }
    }
}
