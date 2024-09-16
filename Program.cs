using HelloWorld.Models; // This is a using directive that allows you to use the Computer class from the HelloWorld.Models namespace
using HelloWorld.Data; // This is a using directive that allows you to use the DataContextEF class from the HelloWorld.Data namespace

namespace HelloWorld
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Create an instance of the DataContext class
            DataContextEF ef = new();

            // Create an instance of the Computer class
            Computer myComputer = new()
            {
                Motherboard = "XPS 24 Turbo",
                CPUCores = 15,
                HasWifi = true,
                HasLTE = true,
                ReleaseDate = new DateTime(2024, 9, 16),
                Price = 3999.99m,
                VideoCard = "Intel Iris Xe3.5"
            };

            // Add the computer to the database
            ef.Add(myComputer);

            // Save the changes to the database
            ef.SaveChanges();

            // Create a query to select all computers from the database using Entity Framework
            IEnumerable<Computer>? computersEF = ef.Computer?.ToList<Computer>();

            if (computersEF != null)
            {
                foreach (Computer computer in computersEF)
                {
                    Console.WriteLine(computer.ComputerId);
                }
            }
        }
    }
}