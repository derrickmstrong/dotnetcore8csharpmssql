// Purpose: To create a class that will be used to connect to the database using Entity Framework.
using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
    public class DataContextEF : DbContext
    {
        // IConfiguration _config - This is a variable that stores the configuration settings for the application - readonly means it can only be set in the constructor
        private readonly IConfiguration _config;

        // DataContextEF constructor
        public DataContextEF(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<Computer>? Computer { get; set; } // This is a property that represents a table in the database that stores Computer objects

        // This is a constructor that takes a DbContextOptions object as a parameter and passes it to the base class constructor (DbContext)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // This is a method that specifies the database provider to use when connecting to the database server using Entity Framework
                optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"), 
                options => options.EnableRetryOnFailure()); // This is a connection string that specifies the server, database, and credentials to use when connecting to the database server using SQL Server
            }
        }

        // This is a method that is called when the model is created
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TutorialAppSchema"); // This is a method that specifies the default schema for the database

            // This is a method that specifies the structure of the Computer table in the database
            modelBuilder.Entity<Computer>(entity =>
            {
                // entity.ToTable("TableName", "SchemaName"); // This is a method that specifies the name of the table in the database that stores Computer objects
                entity.HasKey(e => e.ComputerId); // This is a method that specifies the primary key of the table
                entity.Property(e => e.Motherboard).IsRequired(); // This is a method that specifies that the Motherboard property is required
                entity.Property(e => e.CPUCores).IsRequired(); // This is a method that specifies that the CPUCores property is required
                entity.Property(e => e.HasWifi).IsRequired(); // This is a method that specifies that the HasWifi property is required
                entity.Property(e => e.HasLTE).IsRequired(); // This is a method that specifies that the HasLTE property is required
                entity.Property(e => e.ReleaseDate).IsRequired(); // This is a method that specifies that the ReleaseDate property is required
                entity.Property(e => e.Price).IsRequired(); // This is a method that specifies that the Price property is required
                entity.Property(e => e.VideoCard).IsRequired(); // This is a method that specifies that the VideoCard property is required
            });
        }

    }

}