using HelloWorld.Models;
using HelloWorld.Data;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HelloWorld
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Configuration builder
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            // Create an instance of the DapperContext class
            DataContextDapper dapper = new DataContextDapper(config);

            // Log/Read JSON file
            string computersJson = File.ReadAllText("Computers.json");

            // Create JsonSerializerOptions object with JsonNamingPolicy.CamelCase option and WriteIndented option
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            // Deserialize JSON file - Convert JSON to C# object (IEnumerable<Computer>) using JsonConvert.DeserializeObject method
            IEnumerable<Computer>? computersNewtonsoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

            // Deserialize JSON file - Convert JSON to C# object (IEnumerable<Computer>) using System.Text.Json.JsonSerializer.Deserialize method
            IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);

            // Loop through the computersNewtonsoft collection
            if (computersNewtonsoft != null)
            {
                foreach (Computer computer in computersNewtonsoft)
                {
                    // Insert statement with parameterized query
                    string sqlInsert = "INSERT INTO TutorialAppSchema.Computer (Motherboard, CPUCores, HasWifi, HasLTE, ReleaseDate, Price, VideoCard) VALUES ('"
                        + EscapeSingleQuote(computer.Motherboard) + "',"
                        + computer.CPUCores + ","
                        + (computer.HasWifi ? 1 : 0) + ","
                        + (computer.HasLTE ? 1 : 0) + ",'"
                        + (computer.ReleaseDate?.ToString("yyyy-MM-dd") ?? "1900-01-01") + "',"
                        + computer.Price + ",'"
                        + EscapeSingleQuote(computer.VideoCard) + "')";
                    // Execute the sql insert statement with parameterized query
                    dapper.ExecuteSql(sqlInsert);
                }
            }
        }

        // Escape single quote
        private static string EscapeSingleQuote(string input)
        {
            string output = input.Replace("'", "''");
            return output;
        }
    }
}