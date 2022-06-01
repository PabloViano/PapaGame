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
	private int Dados = 5;
	private int Puntos = 0;
	private bool Estado = true;
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
	public int VerificarPuntos(int[] numeros)
	{
		if (numeros.Distinct().Count() == 5)
		{
			Puntos += EscaleraOPapa(numeros);
		}
		else
		{
			if (Coincidencias(numeros) != 0 && Dados >= 2)
			{
				Puntos += Coincidencias(numeros);
			}
			if (Dados < 2) { Estado = false; }
		}
		return this.Puntos;
	}
	private int EscaleraOPapa(int[] numeros)
	{
		int puntos = -100;
		numeros = numeros.OrderBy(x => x).ToArray();
		if ((numeros[0] == 1 && numeros[numeros.Length] == 5) || (numeros[0] == 2 && numeros[numeros.Length] == 6))
		{
			puntos = 20;
		}
		return puntos;
	}
	private int Coincidencias(int[] numeros)
	{
		List<int> num = numeros.ToList();
		int puntos = 0;
		foreach (int item in numeros)
		{
			int repeticiones = num.FindAll(x => x == item).Count;
			if (repeticiones >= 1)
			{
				puntos += item * repeticiones;
			}
			this.Dados -= repeticiones;
		}
		return puntos;
	}
	public int ReturnDados() { return Dados; }

}
