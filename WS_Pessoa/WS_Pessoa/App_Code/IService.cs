/*
 * 
 * Paulo Antunes e João Paiva
 * Contactos: a11582@alunos.ipca.pt & a14154@alunos.ipca.pt
 * Desc: Web Service Pessoa
 * 
 */

using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data;

[ServiceContract]
public interface IService
{

	[OperationContract]
	string GetData(int value);

	[OperationContract]
	CompositeType GetDataUsingDataContract(CompositeType composite);

	[OperationContract]
	PessoaS CheckLogin(string user, string password);

	[OperationContract]
	string CheckRegisto(string user, string password, string nome, string localidade, int idade, int bi);

	[OperationContract]
	string EfetuaReserva(int userid, int eventid);

	[OperationContract]
	string RemoveReserva(int userid, int eventid);

	[OperationContract]
	string ExisteReserva(PessoaS user, EventoS2 evento);

	[OperationContract]
	string EliminaPessoa(int id);

	[OperationContract]
	PessoaS[] GetAllUsers();

	[OperationContract]
	PessoaS GetPessoa(int id, string username, string nome, int tipo, int idade, string localidade, int ident);

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
/// Define Classe pessoa
/// </summary>
[DataContract]
public class PessoaS
{
	//variaveis
	int id;
	string username;
	string nome;
	int tipo;
	int idade;
	string localidade;
	int bi;

	/// <summary>
	/// Default
	/// </summary>
	public PessoaS() { }

	public PessoaS(int uid, string u, string n, int t, int i, string loca, int ident)
    {
		id = uid;
		username = u;
		nome = n;
		tipo = t;
		idade = i;
		localidade = loca;
		bi = ident;
    }

	[DataMember]
	public int Id
	{
		get { return id; }
		set { id = value; }
	}

	[DataMember]
	public string Username
	{
		get { return username; }
		set { username = value; }
	}

	[DataMember]
	public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

	[DataMember]
	public int Tipo
	{
		get { return tipo; }
		set { tipo = value; }
	}

	[DataMember]
	public int Idade
    {
        get { return idade; }
        set { idade = value; }
    }

	[DataMember]
	public string Localidade
    {
        get { return localidade; }
        set { localidade = value; }
    }


	[DataMember]
	public int Bi
    {
        get { return bi; }
        set { bi = value; }
    }
}

/// <summary>
/// Define Classe evento
/// </summary>

[DataContract]
public class EventoS2
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
	public EventoS2() { }

	public EventoS2(int i, string n, string d, string loca, int lot, int cap)
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