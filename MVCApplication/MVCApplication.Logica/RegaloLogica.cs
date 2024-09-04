using MVCApplication.Entidad;

namespace MVCApplication.Logica
{

    public interface IRegaloLogica { 
        List<Regalo> GetRegalos();
        void AgregarRegalo(Regalo regalo);

    }


    public class RegaloLogica : IRegaloLogica
    {
        static List<Regalo> regalosData { get; set; }

        public RegaloLogica() { 
            regalosData = new List<Regalo>();
            regalosData.Add(new Regalo("Juguete", 200.50, "/images/juguete.jpg"));
            regalosData.Add(new Regalo("Dulce", 100.50, "/images/dulce.jpg"));
            regalosData.Add(new Regalo("Juego", 400, "/images/juego.jpg"));
        }

        public List<Regalo> GetRegalos()
        {
            return regalosData;
        }

        public void AgregarRegalo(Regalo regalo)
        {
            regalosData.Add(regalo);
        }

    }
}
