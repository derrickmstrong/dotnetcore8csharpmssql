// Models - This is a class that defines the structure of an object
namespace HelloWorld.Models
{
    public class Computer
    {
        public int ComputerId { get; internal set; } // This is a property that represents the primary key of the table
        public string Motherboard { get; set; } = "";
        public int CPUCores { get; set; }
        public bool HasWifi { get; set; }
        public bool HasLTE { get; set; }
        public DateTime? ReleaseDate { get; set; } // This is a property that represents a nullable DateTime
        public decimal Price { get; set; }
        public string VideoCard { get; set; } = "";
    }
}