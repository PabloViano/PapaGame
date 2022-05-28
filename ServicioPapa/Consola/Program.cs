using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.ServiceClient service = new ServiceReference1.ServiceClient();
            Console.WriteLine("Comienza el juego");
            bool Estado = true;
            while (Estado)
            {
                int puntos = service.VerificarPuntos(ObtenerNumeros(5));
            }
            
        }
        private List<int> ObtenerNumeros(int dados)
        {
            List<int> Numeros = new List<int>();
            for (int i = 0; i <= dados; i++)
            {
                Random n1 = new Random();
                n1.Next(1, 6);
                Numeros.Add(int.Parse(n1.ToString()));
            }
            return Numeros;
        }
    }
}
