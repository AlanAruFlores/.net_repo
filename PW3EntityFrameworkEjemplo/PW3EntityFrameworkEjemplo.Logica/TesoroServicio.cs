using PW3EntityFrameworkEjemplo.Data.Entidades;

namespace PW3EntityFrameworkEjemplo.Logica
{
    public interface ITesoroServicio
    {
        List<Tesoro> ObtenerTodosLosTesoros();
        Tesoro ObtenerTesoroPorId(int id);
        void AgregarTesoro(Tesoro tesoro);
        void EliminarTesoro(int id);

        void ActualizarTesoro(Tesoro tesoro);


    }


    public class TesoroServicio : ITesoroServicio
    {
        Pw3TesoroContext _pw3TesoroContext; // CONTEXTO
        public TesoroServicio(Pw3TesoroContext contexto) {
            this._pw3TesoroContext = contexto;
        }

        public List<Tesoro> ObtenerTodosLosTesoros() {
            return _pw3TesoroContext.Tesoros.ToList();
        }

        public Tesoro ObtenerTesoroPorId(int id)
        {
            return _pw3TesoroContext.Tesoros.ToList()
                .Where(t => t.Id == id).First();

        }

        public void AgregarTesoro(Tesoro tesoro) { 
            _pw3TesoroContext.Tesoros.Add(tesoro);
            _pw3TesoroContext.SaveChanges();
        }

        public void EliminarTesoro(int id) {
            Tesoro tesoro = ObtenerTesoroPorId(id);

            if (tesoro == null)
                return;

            _pw3TesoroContext.Tesoros.Remove(tesoro);
            _pw3TesoroContext.SaveChanges();
        }

        public void ActualizarTesoro(Tesoro tesoro)
        {
            _pw3TesoroContext.Tesoros.Update(tesoro);
            _pw3TesoroContext.SaveChanges();
        }
    }
}
