/*
 * 
 * Paulo Antunes e João Paiva
 * Contactos: a11582@alunos.ipca.pt & a14154@alunos.ipca.pt
 * Desc: Web Service Pessoa
 * 
 */

using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;        //Access; SQLServer;

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
	/// Tenta fazer login
	/// </summary>
	/// <param name="user"></param>
	/// <param name="password"></param>
	/// <returns></returns>

	public PessoaS CheckLogin(string user, string password)
	{
		PessoaS pessoa = new PessoaS();

		DataSet ds = new DataSet();

		//1º ConnectionString no Web Config
		string cs = ConfigurationManager.ConnectionStrings["databaseConnectionString"].ConnectionString;

		//2º OpenConnection
		OleDbConnection con = new OleDbConnection(cs);      //via OleDB

		//3º Query
		string q = "select * from Users where user=@user and password=@password";

		//4º Execute
		OleDbDataAdapter da = new OleDbDataAdapter(q, con);

		da.SelectCommand.Parameters.Add("@user", OleDbType.Char);
		da.SelectCommand.Parameters["@user"].Value = user;
		da.SelectCommand.Parameters.Add("@password", OleDbType.Char);
		da.SelectCommand.Parameters["@password"].Value = password;

		da.Fill(ds, "Check Login");

        if (ds.Tables[0].Rows.Count == 1) // se encontrar user com esse username e password
        {
            DataRow row = ds.Tables[0].Rows[0];

            pessoa.Id = Int32.Parse(row["id"].ToString());
            pessoa.Username = row["user"].ToString();
            pessoa.Nome = row["nome"].ToString();
            pessoa.Tipo = Int32.Parse(row["tipo"].ToString());
            pessoa.Idade = Int32.Parse(row["idade"].ToString());
            pessoa.Localidade = row["localidade"].ToString();
            pessoa.Bi = Int32.Parse(row["bi"].ToString());
        }
        else
        {
            pessoa.Nome = "Erro. Username ou password incorrectos.";
            pessoa.Tipo = 2;
        }
        return pessoa;
    }

	/// <summary>
	/// Tenta fazer registo
	/// </summary>
	/// <param name="user"></param>
	/// <param name="password"></param>
	/// <param name="nome"></param>
	/// <param name="localidade"></param>
	/// <param name="idade"></param>
	/// <param name="bi"></param>
	/// <returns></returns>

	public string CheckRegisto(string user, string password, string nome, string localidade, int idade, int bi)
	{
		string resultado = "Função registo não chegou a correr, erro inesperado.";
		
		DataSet ds = new DataSet();

		//1º ConnectionString no Web Config
		string cs = ConfigurationManager.ConnectionStrings["databaseConnectionString"].ConnectionString;

		//2º OpenConnection
		OleDbConnection con = new OleDbConnection(cs);      //via OleDB

		//3º Query
		string q1 = "select count (*) from Users where user=@user";

		//4º Execute
		OleDbDataAdapter da = new OleDbDataAdapter(q1, con);

		da.SelectCommand.Parameters.Add("@user", OleDbType.Char);
		da.SelectCommand.Parameters["@user"].Value = user;

		da.Fill(ds, "Check User Existente");

		DataRow row = ds.Tables[0].Rows[0];

		if (row[0].Equals(1))
		{
			resultado = "Username já existente.";
			return resultado;
		}
		else
		{
			OleDbCommand com = new OleDbCommand();

			con.Open();

			com.Connection = con;
			com.CommandText = "INSERT into Users([user], [password], [tipo], [Nome], [Localidade], [Idade], [BI]) Values (@user, @password, @tipo, @nome, @localidade, @idade, @bi)";

			com.Parameters.AddWithValue("@user", user);
			com.Parameters.AddWithValue("@password", password);
			com.Parameters.AddWithValue("@tipo", 0);
			com.Parameters.AddWithValue("@nome", nome);
			com.Parameters.AddWithValue("@localidade", localidade);
			com.Parameters.AddWithValue("@idade", idade);
			com.Parameters.AddWithValue("@bi", bi);

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
	/// Tenta fazer uma reserva de um utilizador num evento
	/// </summary>
	/// <param name="userid"></param>
	/// <param name="eventid"></param>
	/// <returns></returns>

	public string EfetuaReserva(int userid, int eventid)
	{
		string resultado = "Função reserva não chegou a correr, erro inesperado.";

		DataSet ds = new DataSet();
		DataSet ds2 = new DataSet();

		//1º ConnectionString no Web Config
		string cs = ConfigurationManager.ConnectionStrings["databaseConnectionString"].ConnectionString;

		//2º OpenConnection
		OleDbConnection con = new OleDbConnection(cs);      //via OleDB

		//3º Query
		string q1 = "select count (*) from Reservas where ID_User=@userid and ID_Evento=@eventid"; //ver se ja existe
		string q2 = "select lotacao from Events where id=@eventid"; //ver lotacao atual

		//4º Execute
		OleDbDataAdapter da = new OleDbDataAdapter(q1, con);		

		da.SelectCommand.Parameters.Add("@userid", OleDbType.SmallInt);
		da.SelectCommand.Parameters["@userid"].Value = userid;
		da.SelectCommand.Parameters.Add("@eventid", OleDbType.SmallInt);
		da.SelectCommand.Parameters["@eventid"].Value = eventid;		

		da.Fill(ds, "Check Reserva Existente");

		DataRow row = ds.Tables[0].Rows[0];

		if (row[0].Equals(1))
		{
			resultado = "Erro. Reserva já efetuada.";
			return resultado;
		}
		else
		{
			OleDbDataAdapter da2 = new OleDbDataAdapter(q2, con);

			da2.SelectCommand.Parameters.Add("@eventid", OleDbType.SmallInt);
			da2.SelectCommand.Parameters["@eventid"].Value = eventid;

			da2.Fill(ds2, "Lotacao");

			DataRow row2 = ds2.Tables[0].Rows[0];

			int newlotacao = (Int32.Parse(row2[0].ToString())) + 1; //adicionar esta reserva à lotação

			OleDbCommand com = new OleDbCommand();
			OleDbCommand com2 = new OleDbCommand();

			con.Open();

			com.Connection = con;
			com2.Connection = con;
			com.CommandText = "Insert Into Reservas([ID_User], [ID_Evento]) Values (@userid, @eventid)";
			com2.CommandText = "Update Events Set lotacao=@newlotacao where id=@eventid";

			com.Parameters.AddWithValue("@userid", userid);
			com.Parameters.AddWithValue("@eventid", eventid);
			com2.Parameters.AddWithValue("@newlotacao", newlotacao);
			com2.Parameters.AddWithValue("@eventid", eventid);

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
	}

	/// <summary>
	/// Tenta remover uma reserva de um utilizador num evento
	/// </summary>
	/// <param name="userid"></param>
	/// <param name="eventid"></param>
	/// <returns></returns>

	public string RemoveReserva(int userid, int eventid)
	{
		string resultado = "Função removereserva não chegou a correr, erro inesperado.";

		DataSet ds = new DataSet();

		//1º ConnectionString no Web Config
		string cs = ConfigurationManager.ConnectionStrings["databaseConnectionString"].ConnectionString;

		//2º OpenConnection
		OleDbConnection con = new OleDbConnection(cs);      //via OleDB

		string q1 = "select [lotacao] from Events where id=@eventid"; //ver lotacao atual

		OleDbDataAdapter da = new OleDbDataAdapter(q1, con);

		da.SelectCommand.Parameters.Add("@eventid", OleDbType.SmallInt);
		da.SelectCommand.Parameters["@eventid"].Value = eventid;

		da.Fill(ds, "Lotacao");

		DataRow row = ds.Tables[0].Rows[0];

		int newlotacao = (Int32.Parse(row[0].ToString())) - 1; //remover esta reserva da lotação

		OleDbCommand com = new OleDbCommand();
		OleDbCommand com2 = new OleDbCommand();

		con.Open();

		com.Connection = con;
		com2.Connection = con;
		com.CommandText = "DELETE from Reservas where ID_User=@userid and ID_Evento=@eventid";
		com2.CommandText = "Update Events Set lotacao=@newlotacao where id=@eventid";

		com.Parameters.AddWithValue("@userid", userid);
		com.Parameters.AddWithValue("@eventid", eventid);
		com2.Parameters.AddWithValue("@newlotacao", newlotacao);
		com2.Parameters.AddWithValue("@eventid", eventid);

		try
		{
			com.ExecuteNonQuery();
			com2.ExecuteNonQuery();
			resultado = "Sucesso";
		}
		catch (Exception erro)
		{
			resultado = "Utilizador não tem reserva neste evento. " + erro.Message;
		}
		finally
		{
			con.Close();
		}
		return resultado;
	}

	/// <summary>
	/// Vê se um utilizador tem reserva num evento
	/// </summary>
	/// <param name="user"></param>
	/// <param name="evento"></param>
	/// <returns></returns>

	public string ExisteReserva(PessoaS user, EventoS2 evento)
	{
		string resultado = "Função existe reserva não chegou a correr, erro inesperado.";

		int userID = user.Id;
		int eventID = evento.Id;

		DataSet ds = new DataSet();

		//1º ConnectionString no Web Config
		string cs = ConfigurationManager.ConnectionStrings["databaseConnectionString"].ConnectionString;

		//2º OpenConnection
		OleDbConnection con = new OleDbConnection(cs);      //via OleDB

		//3º Querry
		string q1 = "select count (*) from Reservas where ID_User = @userID and ID_Evento = @eventID";

		//4º Execute
		OleDbDataAdapter da = new OleDbDataAdapter(q1, con);

		da.SelectCommand.Parameters.Add("@userID", OleDbType.SmallInt);
		da.SelectCommand.Parameters["@userID"].Value = userID;
		da.SelectCommand.Parameters.Add("@eventID", OleDbType.SmallInt);
		da.SelectCommand.Parameters["@eventID"].Value = eventID;

		da.Fill(ds, "Check Reserva");

		DataRow row = ds.Tables[0].Rows[0];

		if (row[0].Equals(1))
		{
			resultado = "Tem";
		}
		else
		{
			resultado = "Nao tem";
		}
		return resultado;
	}

	/// <summary>
	/// Elimina uma pessoa da base de dados
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>

	public string EliminaPessoa(int id)
	{
		string resultado = "Função elimina pessoa não chegou a correr, erro inesperado.";

		DataSet ds = new DataSet();

		//1º ConnectionString no Web Config
		string cs = ConfigurationManager.ConnectionStrings["databaseConnectionString"].ConnectionString;

		//2º OpenConnection
		OleDbConnection con = new OleDbConnection(cs);      //via OleDB

		OleDbCommand com = new OleDbCommand();		// apagar na tabela Users
		OleDbCommand com2 = new OleDbCommand();		// apagar na tabela Reservas

		con.Open();

		com.Connection = con;
		com2.Connection = con;
		com.CommandText = "DELETE from Users where id=@id";
		com2.CommandText = "DELETE from Reservas where ID_User=@iduser";

		com.Parameters.AddWithValue("@id", id);
		com2.Parameters.AddWithValue("@iduser", id);

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
	/// Devolve todos os users
	/// </summary>
	/// <returns></returns>

	public PessoaS[] GetAllUsers()
	{
		PessoaS[] erroArray = new PessoaS[2];

		DataSet ds = new DataSet();

		//1º ConnectionString no Web Config
		string cs = ConfigurationManager.ConnectionStrings["databaseConnectionString"].ConnectionString;

		//2º OpenConnection
		OleDbConnection con = new OleDbConnection(cs);      //via OleDB

		//3º Query
		string q = "select * from Users";

		//4º Execute
		OleDbDataAdapter da = new OleDbDataAdapter(q, con);

		da.Fill(ds, "Users");

		int size_users = ds.Tables[0].Rows.Count; // numero total de users

		PessoaS[] listaPessoas = new PessoaS[size_users];
		for (int i = 0; i < size_users; i++)
		{
			listaPessoas[i] = new PessoaS();
		}

		try
		{


			int i = 0;
			foreach (DataRow drow in ds.Tables[0].Rows) // percorre todas as linhas
			{
				listaPessoas[i].Id = Int32.Parse(drow["id"].ToString());
				listaPessoas[i].Username = drow["user"].ToString();
				listaPessoas[i].Nome = drow["nome"].ToString();
				listaPessoas[i].Tipo = Int32.Parse(drow["tipo"].ToString());
				listaPessoas[i].Idade = Int32.Parse(drow["idade"].ToString());
				listaPessoas[i].Localidade = drow["localidade"].ToString();
				listaPessoas[i].Bi = Int32.Parse(drow["bi"].ToString());
				i++;
			}
			return listaPessoas;
		}
		catch (Exception erro)
		{
			erroArray[0].Nome = "Erro";
			erroArray[1].Nome = erro.Message;
			return erroArray;
		}
	}

	/// <summary>
	/// Adiciona uma pessoa
	/// </summary>
	/// <param name="id"></param>
	/// <param name="username"></param>
	/// <param name="nome"></param>
	/// <param name="tipo"></param>
	/// <param name="idade"></param>
	/// <param name="localidade"></param>
	/// <param name="ident"></param>
	/// <returns></returns>

	public PessoaS GetPessoa(int id, string username, string nome, int tipo, int idade, string localidade, int ident)
	{
		PessoaS p = new PessoaS();

		p.Id = id;
		p.Username = username;
		p.Nome = nome;
		p.Tipo = tipo;
		p.Idade = idade;
		p.Localidade = localidade;
		p.Bi = ident;

		return p;
	}
}