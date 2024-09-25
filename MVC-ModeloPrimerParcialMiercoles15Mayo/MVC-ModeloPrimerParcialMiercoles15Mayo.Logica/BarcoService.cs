using MVC_ModeloPrimerParcialMiercoles15Mayo.Entidades;

namespace MVC_ModeloPrimerParcialMiercoles15Mayo.Logica
{

    public interface IBarcoService
    {
        public void RegistrarBarco(Barco barco);

        public List<Barco> ObtenerListaDeBarcos();

    }
    public class BarcoService : IBarcoService
    {
        static List<Barco> listaBarcos = new List<Barco>();

        public List<Barco> ObtenerListaDeBarcos()
        {
            return listaBarcos;
        }

        public void RegistrarBarco(Barco barco)
        {
            barco.Tasa = CalcularTasaBarco(barco);
            listaBarcos.Add(barco);
        }

        private int CalcularTasaBarco(Barco barco)
        => (barco.Antiguedad * (1 / 10)) + (barco.TripulacionMaxima / 2);
        
    }
}
