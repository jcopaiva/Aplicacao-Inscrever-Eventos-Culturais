/*
 * 
 * Paulo Antunes e João Paiva
 * Contactos: a11582@alunos.ipca.pt & a14154@alunos.ipca.pt
 * Desc: Web Service Evento
 * 
 */

using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

	[OperationContract]
	string GetData(int value);

	[OperationContract]
	CompositeType GetDataUsingDataContract(CompositeType composite);

	[OperationContract]
	string CriarEvento(string nome, string data, string local, int lotacao, int capacidade);

	[OperationContract]
	string EliminaEvento(int id);

	[OperationContract]
	EventoS[] GetAllEvents();

	[OperationContract]
	EventoS EscolherEvento(string nome);

	[OperationContract]
	EventoS GetEvento(int id, string nome, string data, string local, int lotacao, int capacidade);
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class CompositeType
{
	bool boolValue = true;
	string stringValue = "Hello ";

	[DataMember]
	public bool BoolValue
	{
		get { return boolValue; }
		set { boolValue = value; }
	}

	[DataMember]
	public string StringValue
	{
		get { return stringValue; }
		set { stringValue = value; }
	}
}

/// <summary>
/// Define Classe evento
/// </summary>
[DataContract]
public class EventoS
{
	//variaveis
	int id;
	string nome;
	string data;
	string local;
	int lotacao;
	int capacidade;

	/// <summary>
	/// Default
	/// </summary>
	public EventoS() { }

	public EventoS(int i, string n, string d, string loca, int lot, int cap)
	{
		id = i;
		nome = n;
		data = d;
		local = loca;
		lotacao = lot;
		capacidade = cap;
	}

	[DataMember]
	public int Id
	{
		get { return id; }
		set { id = value; }
	}

	[DataMember]
	public string Nome
	{
		get { return nome; }
		set { nome = value; }
	}

	[DataMember]
	public string Data
	{
		get { return data; }
		set { data = value; }
	}

	[DataMember]
	public string Localizacao
	{
		get { return local; }
		set { local = value; }
	}

	[DataMember]
	public int Lotacao
	{
		get { return lotacao; }
		set { lotacao = value; }
	}

	[DataMember]
	public int Capacidade
	{
		get { return capacidade; }
		set { capacidade = value; }
	}
}