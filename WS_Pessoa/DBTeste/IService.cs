/*
 * 
 * Paulo Antunes e João Paiva
 * Contactos: a11582@alunos.ipca.pt & a14154@alunos.ipca.pt
 * Desc: Web Service Central
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

	[OperationContract]
	string GetData(int value);

	[OperationContract]
	CompositeType GetDataUsingDataContract(CompositeType composite);


	[OperationContract]
	PessoaS GetPessoa(string nome, int idade, string localidade, int ident);

	[OperationContract]
	PessoaS[] TodoArray();

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
	string nome;
	int idade;
	string localidade;
	int bi;

	/// <summary>
	/// Default
	/// </summary>
	public PessoaS() { }

	public PessoaS(string n, int i, string loca, int ident)
    {
		nome = n;
		idade = i;
		localidade = loca;
		bi = ident;
    }

	[DataMember]
	public string Nome
    {
        get { return nome; }
        set { nome = value; }
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