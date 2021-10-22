/*
 * 
 * Paulo Antunes e João Paiva
 * Contactos: a11582@alunos.ipca.pt & a14154@alunos.ipca.pt
 * Desc: Web Service Evento
 * 
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

public class Evento : IService
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
	/// Tenta criar um evento
	/// </summary>
	/// <param name="nome"></param>
	/// <param name="data"></param>
	/// <param name="local"></param>
	/// <param name="lotacao"></param>
	/// <param name="capacidade"></param>
	/// <returns></returns>

	public string CriarEvento(string nome, string data, string local, int lotacao, int capacidade)
	{
		string resultado = "Função criar evento não chegou a correr, erro inesperado.";

		DataSet ds = new DataSet();

		//1º ConnectionString no Web Config
		string cs = ConfigurationManager.ConnectionStrings["databaseConnectionString"].ConnectionString;

		//2º OpenConnection
		OleDbConnection con = new OleDbConnection(cs);      //via OleDB

		//3º Query
		string q1 = "select count (*) from Events where nome=@nome";

		//4º Execute
		OleDbDataAdapter da = new OleDbDataAdapter(q1, con);

		da.SelectCommand.Parameters.Add("@nome", OleDbType.Char);
		da.SelectCommand.Parameters["@nome"].Value = nome;

		da.Fill(ds, "Check Evento Existente");

		DataRow row = ds.Tables[0].Rows[0];

		if (row[0].Equals(1))
		{
			resultado = "Já existe um evento com esse nome.";
			return resultado;
		}
		else
		{
			OleDbCommand com = new OleDbCommand();

			con.Open();

			com.Connection = con;
			com.CommandText = "INSERT into Events([nome], [data], [local], [lotacao], [capacidade]) Values (@nome, @data, @local, @lotacao, @capacidade)";

			com.Parameters.AddWithValue("@nome", nome);
			com.Parameters.AddWithValue("@data", data);
			com.Parameters.AddWithValue("@local", local);
			com.Parameters.AddWithValue("@lotacao", 0);
			com.Parameters.AddWithValue("@capacidade", capacidade);

			try
			{
				com.ExecuteNonQuery();
				resultado = "Sucesso";
			}
			catch (Exception erro)
			{
				resultado = erro.Message;
			}
			finally
			{
				con.Close();
			}
			return resultado;
		}
	}

	/// <summary>
	/// Elimina um evento da base de dados
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>

	public string EliminaEvento(int id)
	{
		string resultado = "Função elimina evento não chegou a correr, erro inesperado.";

		DataSet ds = new DataSet();

		//1º ConnectionString no Web Config
		string cs = ConfigurationManager.ConnectionStrings["databaseConnectionString"].ConnectionString;

		//2º OpenConnection
		OleDbConnection con = new OleDbConnection(cs);      //via OleDB

		OleDbCommand com = new OleDbCommand();      // apagar na tabela Events
		OleDbCommand com2 = new OleDbCommand();     // apagar na tabela Reservas

		con.Open();

		com.Connection = con;
		com2.Connection = con;
		com.CommandText = "DELETE from Events where id=@id";
		com2.CommandText = "DELETE from Reservas where ID_Evento=@idevento";

		com.Parameters.AddWithValue("@id", id);
		com2.Parameters.AddWithValue("@idevento", id);

		try
		{
			com.ExecuteNonQuery();
			com2.ExecuteNonQuery();
			resultado = "Sucesso";
		}
		catch (Exception erro)
		{
			resultado = erro.Message;
		}
		finally
		{
			con.Close();
		}
		return resultado;
	}


	/// <summary>
	/// Devolve todos os eventos
	/// </summary>
	/// <returns></returns>

	public EventoS[] GetAllEvents()
	{
		EventoS[] erroMensagem = new EventoS[2];

		DataSet ds = new DataSet();

		//1º ConnectionString no Web Config
		string cs = ConfigurationManager.ConnectionStrings["databaseConnectionString"].ConnectionString;

		//2º OpenConnection
		OleDbConnection con = new OleDbConnection(cs);      //via OleDB

		//3º Query
		string q = "select * from Events";

		//4º Execute
		OleDbDataAdapter da = new OleDbDataAdapter(q, con);

		da.Fill(ds, "Events");

		int size_events = ds.Tables[0].Rows.Count; // numero total de eventos

		EventoS[] listaEventos = new EventoS[size_events];
        for (int i = 0; i < size_events; i++)
        {
			listaEventos[i] = new EventoS();
		}

		try
		{
			int i = 0;
			foreach (DataRow drow in ds.Tables[0].Rows) // percorre todas as linhas
			{
				listaEventos[i].Id = Int32.Parse(drow["id"].ToString());
				listaEventos[i].Nome = drow["nome"].ToString();
				listaEventos[i].Data = drow["data"].ToString();
				listaEventos[i].Localizacao = drow["local"].ToString();
				listaEventos[i].Lotacao = Int32.Parse(drow["lotacao"].ToString());
				listaEventos[i].Capacidade = Int32.Parse(drow["capacidade"].ToString());
				i++;
			}
			return listaEventos;
		}
		catch (Exception erro)
		{
			erroMensagem[0].Nome = "Erro";
			erroMensagem[1].Nome = erro.Message;
			return erroMensagem;
		}
	}

	/// <summary>
	/// Devolve um evento
	/// </summary>
	/// <returns></returns>

	public EventoS EscolherEvento(string nome)
	{
		EventoS evento = new EventoS();

		DataSet ds = new DataSet();

		//1º ConnectionString no Web Config
		string cs = ConfigurationManager.ConnectionStrings["databaseConnectionString"].ConnectionString;

		//2º OpenConnection
		OleDbConnection con = new OleDbConnection(cs);      //via OleDB

		//3º Query
		string q = "Select * from Events where nome=@nome";

		//4º Execute
		OleDbDataAdapter da = new OleDbDataAdapter(q, con);

		da.SelectCommand.Parameters.Add("@nome", OleDbType.Char);
		da.SelectCommand.Parameters["@nome"].Value = nome;

		da.Fill(ds, "Evento");

		DataRow drow = ds.Tables[0].Rows[0];

		try
		{
			evento.Id = Int32.Parse(drow["id"].ToString());
			evento.Nome = drow["nome"].ToString();
			evento.Data = drow["data"].ToString();
			evento.Localizacao = drow["local"].ToString();
			evento.Lotacao = Int32.Parse(drow["lotacao"].ToString());
			evento.Capacidade = Int32.Parse(drow["capacidade"].ToString());
		}
		catch (Exception erro)
		{
			evento.Nome = erro.Message;
		}
		return evento;
	}

	/// <summary>
	/// Adiciona um evento
	/// </summary>
	/// <param name="nome"></param>
	/// <param name="data"></param>
	/// <param name="local"></param>
	/// <param name="lotacao"></param>
	/// <param name="capacidade"></param>
	/// <returns></returns>

	public EventoS GetEvento(int id, string nome, string data, string local, int lotacao, int capacidade)
	{
		EventoS e = new EventoS();

		e.Id = id;
		e.Nome = nome;
		e.Data = data;
		e.Localizacao = local;
		e.Lotacao = lotacao;
		e.Capacidade = capacidade;

		return e;
	}
}