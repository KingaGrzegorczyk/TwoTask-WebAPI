using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationBuilder = Microsoft.Extensions.Configuration.ConfigurationBuilder;

namespace TwoTaskLibrary.Internal.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        public IConfiguration Configuration { get; }
        public SqlDataAccess()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            Configuration = config.Build(); 
        }

        public List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connectionString = Configuration[connectionStringName];

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        public void SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = Configuration[connectionStringName];

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure); 
            }
        }
        public void UpdateData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = Configuration[connectionStringName];

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = Configuration[connectionStringName];

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
