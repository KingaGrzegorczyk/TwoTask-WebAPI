using System;
using System.Data;
using System.Data.SqlClient;

public interface ISqlDataFactory
{
    IDbConnection GetOpenConnection();
}

public class SqlDataFactory : ISqlDataFactory, IDisposable
{
    private readonly string _connectionString;
    private IDbConnection _connection;

    public SqlDataFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection GetOpenConnection()
    {
        if (this._connection == null || this._connection.State != ConnectionState.Open)
        {
            this._connection = new SqlConnection(_connectionString);
            this._connection.Open();
        }
        return this._connection;
    }

    public void Dispose()
    {
        if (this._connection != null && this._connection.State == ConnectionState.Open)
            this._connection.Dispose();
    }
}