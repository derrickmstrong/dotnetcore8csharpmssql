using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace HelloWorld.Data
{
    public class DataContextDapper
    {
        // create connection to the database
        private string _connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=false;Uid=sa;Pwd=SQLConnect1;";

        // query method - returns IEnumerable of T type of data
        public IEnumerable<T> LoadData<T>(string sql)
        {
            // create a connection to the database
            IDbConnection dbConnection = new SqlConnection(_connectionString);

            // query the database
            var query = dbConnection.Query<T>(sql);

            // return the results
            return query;
        }
        // query single method - returns single object of T type of data
        public T LoadDataSingle<T>(string sql)
        {
            // create a connection to the database
            IDbConnection dbConnection = new SqlConnection(_connectionString);

            // query the database
            var query = dbConnection.QuerySingle<T>(sql);

            // return the results
            return query;
        }
        // execute method - executes sql
        public bool ExecuteSql(string sql)
        {
            // create a connection to the database
            IDbConnection dbConnection = new SqlConnection(_connectionString);

            // Execute the sql
            var execute = dbConnection.Execute(sql);

            return execute > 0;
        }
        // execute method - executes sql
        public int ExecuteSqlWithRowCount(string sql)
        {
            // create a connection to the database
            IDbConnection dbConnection = new SqlConnection(_connectionString);

            // Execute the sql
            var execute = dbConnection.Execute(sql);

            return execute;
        }

    }
}