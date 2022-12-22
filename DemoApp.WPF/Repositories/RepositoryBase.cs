using System;
using System.Data.SQLite;

namespace DemoApp.WPF.Repositories;

public abstract class RepositoryBase
{
    private readonly String _connectionString;

	protected SQLiteConnection GetConnection()
	{
		return new SQLiteConnection(_connectionString, true);
	}

	public RepositoryBase()
	{
		_connectionString = new SQLiteConnectionStringBuilder
		{
			DataSource = ".\\DemoDb.db",
			Version = 3			
		}.ConnectionString;
	}
}
