using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
    public class DataContextDapper
    {
        // create connection to the database
        // IConfiguration _config - This is a variable that stores the configuration settings for the application - readonly means it can only be set in the constructor
        private readonly IConfiguration _config;
        
        // DataContextDapper constructor
        public DataContextDapper(IConfiguration config)
        {
            _config = config;
        }

        // query method - returns IEnumerable of T type of data
        public IEnumerable<T> LoadData<T>(string sql)
        {
            // create a connection to the database
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection")); // get connection string from appsettings.json file

            // query the database
            var query = dbConnection.Query<T>(sql);

            // return the results
            return query;
        }
        // query single method - returns single object of T type of data
        public T LoadDataSingle<T>(string sql)
        {
            // create a connection to the database
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection")); // get connection string from appsettings.json file

            // query the database
            var query = dbConnection.QuerySingle<T>(sql);

            // return the results
            return query;
        }
        // execute method - executes sql
        public bool ExecuteSql(string sql)
        {
            // create a connection to the database
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection")); // get connection string from appsettings.json file

            // Execute the sql
            var execute = dbConnection.Execute(sql);

            return execute > 0;
        }
        // execute method - executes sql
        public int ExecuteSqlWithRowCount(string sql)
        {
            // create a connection to the database
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection")); // get connection string from appsettings.json file

            // Execute the sql
            var execute = dbConnection.Execute(sql);

            return execute;
        }

    }
}