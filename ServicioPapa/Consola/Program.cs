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
                int[] Numeros = ObtenerNumeros(service.ReturnDados()).ToArray();
                Console.WriteLine("Los numeros que salieron son: ");
                foreach (int item in Numeros)
                {
                    Console.WriteLine(item);
                }
                int puntos = service.VerificarPuntos(Numeros);
                Console.WriteLine($"Puntos totales son: {puntos}");
                if (service.ReturnDados() < 2) { Estado = false;}
            }
            
        }
        private static List<int> ObtenerNumeros(int dados)
        {
            List<int> Numeros = new List<int>();
            Random n1 = new Random();
            for (int i = 0; i <= dados; i++)
            {
                Numeros.Add(n1.Next(1, 6));
            }
            return Numeros;
        }
    }
}
