// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MySQL.cs" company="Simon Carpentier">
//   
// </copyright>
// <summary>
//   Classe de connexion MySQL
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SPACEBAR.Database
{
	using System;
	using System.Data;

	using MySql.Data.MySqlClient;

	/// <summary>
	/// Classe de connexion MySQL
	/// </summary>
	public class MySQL
	{
		public MySqlConnection SQLCon; 

		public MySQL(MySqlConnection SQLCon) 
		{ 
		this.SQLCon = SQLCon; 
		}

		public MySQL()
		{
		}

		public MySQL(string SQLCon) 
		{
			this.SQLCon = new MySqlConnection(SQLCon); 
			}

		public MySQL(string host, string database, string username, string password)
		{
		this.SQLCon = new MySqlConnection(GenerateSQLCon(host, database, username, password));
		}

		protected static string GenerateSQLCon(string host, string database, string username, string password)
		{
			return String.Format("Server={0};Database={1};Uid={2};Pwd={3};", host, database, username, password);
		}

		public object ExecuteNonQuery(string query)
		{
			var sqlCommand = new MySqlCommand(query, this.SQLCon);
			try
			{
				sqlCommand.Connection.Open();
				object obj = sqlCommand.ExecuteNonQuery();
				return obj;
			}
			catch (Exception ex)
			{
				throw;
			}
			finally
			{
				sqlCommand.Connection.Close();
			}
		}

		public DataSet GetDataSet(string query) 
		{ 
			var sqlCommand = new MySqlCommand(query, this.SQLCon); 
			var sqlDataAdapter = new MySqlDataAdapter(sqlCommand); 
			var ds = new DataSet(); 
			sqlDataAdapter.Fill(ds); 
			return ds; 
		} 

		public object ExecuteScalar(string query)
		{
			var sqlCommand = new MySqlCommand(query);
			try
			{
				sqlCommand.Connection = SQLCon;
				sqlCommand.Connection.Open();
				object scalar = sqlCommand.ExecuteScalar();
				return scalar;
			}
			catch (Exception ex)
			{
				throw;
			}
			finally
			{
				sqlCommand.Connection.Close();
			}
		}

		public object ExecuteReader(string query) 
		{ 
			var sqlCommand = new MySqlCommand(query); 
			try { 
				sqlCommand.Connection = SQLCon; 
				sqlCommand.Connection.Open();
				object reader = sqlCommand.ExecuteReader();
				return reader; 
			} catch (Exception ex) { 
				throw ex; 
			} finally { 
				sqlCommand.Connection.Close(); 
			} 
		} 

		public bool Exists(string query) 
		{ 
			DataSet ds = GetDataSet(query);
			return ds.Tables[0].Rows.Count != 0;
		}
	}
}
