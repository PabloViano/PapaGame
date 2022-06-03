using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de LogicaJuego
/// </summary>
public class LogicaJuego
{
    public class DatoJuego
    {
        public int Numero { get; set; }
        public int Repeticiones { get; set; }
        public int Suma { get; set; }
    }
    public DatoJuego[] datosJuego = new DatoJuego[]
        {
            new DatoJuego(){Numero = 1, Repeticiones = 0, Suma = 0},
            new DatoJuego(){Numero = 2, Repeticiones = 0, Suma = 0},
            new DatoJuego(){Numero = 3, Repeticiones = 0, Suma=0},
            new DatoJuego(){Numero = 4, Repeticiones = 0, Suma=0},
            new DatoJuego(){Numero = 5, Repeticiones = 0,Suma=0},
            new DatoJuego(){Numero= 6, Repeticiones = 0, Suma=0},
        };
    private void DatosCompletos(Dado[] dados)
        {
            foreach (var dado in dados)
            {
                foreach (var juego in datosJuego)
                {
                    if (dado.Numero == juego.Numero)
                    {
                        juego.Repeticiones += 1;
                        juego.Suma += dado.Numero;
                    }
                }
            }
        }
    internal Resultado VerificarPuntos(Dado[] dados)
    {
        DatosCompletos(dados);
        List<DatoJuego> dadosActuales = datosJuego.Where(x => x.Repeticiones > 0).ToList();
        dadosActuales = dadosActuales.OrderBy(x => x.Numero).ToList();
        if (dadosActuales.Select(x => x.Numero).Distinct().Count() == 5)
        {
            if (
                    (dadosActuales.Any(x => x.Numero == 1) && !dadosActuales.Any(x => x.Numero == 6)) ||
                    (dadosActuales.Any(x => x.Numero == 6) && !dadosActuales.Any(x => x.Numero == 1))
                )
            {
                return new Resultado { DadosRestantes = 5, Estado = true, Puntos = 20 };
            }
            else
            {
                return new Resultado { DadosRestantes = 0, Estado = false, Puntos = -100 };
            }
        }
        else
        {
            int PuntosJuego = 0;
            var dadosRestantes = 0;
            foreach (var dado in dadosActuales)
            {
                if (dado.Repeticiones > 1) { PuntosJuego += dado.Suma; dadosRestantes += dado.Repeticiones; }
            }
            return new Resultado { DadosRestantes = dadosRestantes, Estado = PuntosJuego == 0, Puntos = PuntosJuego };
        }
    }

}
