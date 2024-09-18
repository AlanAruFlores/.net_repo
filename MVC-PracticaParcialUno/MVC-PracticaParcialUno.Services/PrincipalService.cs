namespace MVC_PracticaParcialUno.Services
{
    public interface IPrincipalService
    {
        public int Sumar(int n1, int n2);
        public int Restar(int n1, int n2);

    }

    public class PrincipalService : IPrincipalService
    {
        public int Restar(int n1, int n2) => n1 - n2;
        public int Sumar(int n1, int n2) => n1 + n2;
    }
}
