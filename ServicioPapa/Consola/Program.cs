using Consola.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.ServiceClient service = new ServiceReference1.ServiceClient();
            var juegos = 0;
            var sumaPuntos = 0;
            Resultado resultado = null;
            var pruebaGenerala1 = new Dado[] { new Dado() { Numero = 1 }, new Dado() { Numero = 3 }, new Dado() { Numero = 4 }, new Dado() { Numero = 5 }, new Dado() { Numero = 2 }, };
            resultado = service.Jugar(pruebaGenerala1);
            sumaPuntos += resultado.Puntos;
            Console.WriteLine($"Puntos totales: {sumaPuntos}, ultimo juego: {resultado.Puntos}: Dados disponibles: {resultado.DadosRestantes}");
            while (juegos < 5)
            {
                Console.WriteLine("--------New-Game----------");
                Console.WriteLine($"-------Game-{juegos + 1}-----");
                var dadosTotal = 5;
                var finalizado = false;
                Random num = new Random();
                sumaPuntos = 0;
                while (!finalizado)
                {
                    Dado[] dados = new Dado[dadosTotal];
                    for (int i = 0; i < dadosTotal; i++)
                    {
                        dados[i] = new Dado { Numero = num.Next(1, 7) };
                    }
                    Console.WriteLine("Salieron los siguientes numeros: ");
                    foreach (var dado in dados)
                    {
                        Console.WriteLine(dado.Numero);
                    }
                    resultado = service.Jugar(dados);
                    Console.WriteLine($"Puntos Totales: {resultado.Puntos} - Dados Restantes: {resultado.DadosRestantes}");
                    sumaPuntos += resultado.Puntos;
                    dadosTotal = resultado.DadosRestantes;
                    finalizado = resultado.Estado;
                }
                Console.WriteLine($"--------Puntos-Totales-[{sumaPuntos}]-------");
                juegos++;
                Thread.Sleep(5000);
            }
            Console.Read();
        }
    }
}
