using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{

	[OperationContract]
	Resultado Jugar(Dado[] dados);

}

[DataContract]
public class Dado
{
	[DataMember]
	public int Numero { get; set; }
}

[DataContract]
public class Resultado
{
	[DataMember]
	public int DadosRestantes { get; set; }

	[DataMember]
	public int Puntos { get; set; }

	[DataMember]
	public bool Estado { get; set; }
}
