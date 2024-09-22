using HelloWorld.Models; // This is a using directive that allows you to use the Computer class from the HelloWorld.Models namespace
using HelloWorld.Data;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json; // This is a using directive that allows you to use the JsonConvert class from the Newtonsoft.Json namespace

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

            // Create an instance of the Computer class
            // Computer myComputer = new()
            // {
            //     Motherboard = "XPS 24 Turbo",
            //     CPUCores = 15,
            //     HasWifi = true,
            //     HasLTE = true,
            //     ReleaseDate = new DateTime(2024, 9, 16),
            //     Price = 3999.99m,
            //     VideoCard = "Intel Iris Xe3.5"
            // };

            // Create sql insert statement
            // string sql = "INSERT INTO Computer (Motherboard, CPUCores, HasWifi, HasLTE, ReleaseDate, Price, VideoCard) VALUES (@Motherboard, @CPUCores, @HasWifi, @HasLTE, @ReleaseDate, @Price, @VideoCard)";

            // Log/Read JSON file
            string computersJson = File.ReadAllText("Computers.json");
            // Console.WriteLine(computersJson);
            
            // Deserialize JSON file - Convert JSON to C# object (IEnumerable<Computer>) using JsonConvert.DeserializeObject method
            IEnumerable<Computer>? computers = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

            if (computers != null)
            {
                foreach (var computer in computers)
                {
                    Console.WriteLine(computer.Motherboard);
                }
            }

        }
    }
}