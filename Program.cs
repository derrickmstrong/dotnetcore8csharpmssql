using HelloWorld.Models; // This is a using directive that allows you to use the Computer class from the HelloWorld.Models namespace
using HelloWorld.Data;
using Microsoft.Extensions.Configuration; // This is a using directive that allows you to use the DataContextEF class from the HelloWorld.Data namespace

namespace HelloWorld
{
    internal class Program
    {
        private static void Main(string[] args)
        {

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

            string sql = "INSERT INTO Computer (Motherboard, CPUCores, HasWifi, HasLTE, ReleaseDate, Price, VideoCard) VALUES (@Motherboard, @CPUCores, @HasWifi, @HasLTE, @ReleaseDate, @Price, @VideoCard)";

            // Write the SQL to a file - this will overwrite the file
            // File.WriteAllText("Computer.txt", sql);
            // Close the file
            // File.Close();

            // Write to stream - this will append to the file
            using (StreamWriter stream = new("Computer.txt", true))
            {
                stream.WriteLine("Motherboard: " + myComputer.Motherboard);
                stream.WriteLine("CPUCores: " + myComputer.CPUCores);
                stream.WriteLine("HasWifi: " + myComputer.HasWifi);
                stream.WriteLine("HasLTE: " + myComputer.HasLTE);
                stream.WriteLine("ReleaseDate: " + myComputer.ReleaseDate);
                stream.WriteLine("Price: " + myComputer.Price);
                stream.WriteLine("VideoCard: " + myComputer.VideoCard + "\n");
                // close the stream
                stream.Close();
            }

            // Write SQL to stream - this will append to the file
            using (StreamWriter stream = new("ComputerSQL.txt", true))
            {
                stream.WriteLine(sql + "\n");
                // close the stream
                stream.Close();
            }

            // Read from stream - this will read the file
            using (StreamReader stream = new("Computer.txt"))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            // Read all text from file - this will read the file
            string text = File.ReadAllText("Computer.txt");
            Console.WriteLine(text);
        }
    }
}