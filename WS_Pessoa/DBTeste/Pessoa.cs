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
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Pessoa" in code, svc and config file together.
public class Pessoa : IService
{
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

	/// <summary>
	/// Adiciona uma pessoa
	/// </summary>
	/// <param name="nome"></param>
	/// <param name="idade"></param>
	/// <param name="loca"></param>
	/// <param name="bi"></param>
	/// <returns></returns>

	public PessoaS GetPessoa(string nome, int idade,string loca,int bi)
    {
		PessoaS p = new PessoaS();

		p.Nome = nome;
		p.Idade = idade;
		p.Localidade = loca;
		p.Bi = bi;

		return p;
    }

	/// <summary>
	/// Tenta efetuar login
	/// </summary>
	/// <param name="user"></param>
	/// <param name="pass"></param>
	/// <param name="tipo"></param>
	/// <returns></returns>



	//ir buscar a DB
	//public PessoaS[] TodoArray()
	//   {
	//	ArrayList aux = new ArrayList();

	//	//teste
	//	aux.Add(new PessoaS("Joao", 20, "braga", 12123));
	//	aux.Add(new PessoaS("Paulo", 22, "Lisboa", 14145));

	//	return (PessoaS[])aux.ToArray(typeof(PessoaS));
	//   }
}