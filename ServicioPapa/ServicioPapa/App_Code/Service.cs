using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
	public int Dados = 5;
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}
	public int VerificarPuntos(List<int> numeros)
    {
		int Puntos = 0;
        if (numeros.Distinct().Count() == 5)
        {
			Puntos += -100;
        }
        else
        {
			if (VerificarEscalera(numeros))
            {
				Puntos += 20;
            }
            else
            {
				if (Coincidencias(numeros) != 0)
				{
					Puntos += Coincidencias(numeros);
				}
			}
        }
		return Puntos;
    }
	private bool VerificarEscalera(List<int> numeros)
    {
		bool Escalera = true;
		numeros = numeros.OrderBy(x => x).ToList();
		int cont = 0;
		while (cont < 4)
        {
			if (numeros[cont] + 1 != numeros[cont + 1])
            {
				Escalera = false;
            }
			cont++;
        }
		return Escalera;
    }
	private int Coincidencias(List<int> numeros)
	{
		int Puntos = 0;
		foreach (int item in numeros)
		{
			int repeticiones = numeros.FindAll(x => x == item).Count;
			if (repeticiones >= 1)
			{
				Puntos += item * repeticiones;
			}
			this.Dados -= repeticiones;
		}
		return Puntos;
	}
}
