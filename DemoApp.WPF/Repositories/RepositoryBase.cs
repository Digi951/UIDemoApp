using System;
using System.Data.SqlClient;

namespace DemoApp.WPF.Repositories;

public abstract class RepositoryBase
{
    private readonly String _connectionString;

	protected SqlConnection GetConnection()
	{
		return new SqlConnection(_connectionString);
	}

	public RepositoryBase()
	{
		_connectionString = "Server=(local); Database=MVVMLoginDb; Integrated Security=true";
	}
}
