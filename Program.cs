using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using HelloWorld.Models; // This is a using directive that allows you to use the Computer class from the HelloWorld.Models namespace
using HelloWorld.Data; // This is a using directive that allows you to use the DataContextDapper class from the HelloWorld.Data namespace   
using Microsoft.Data.SqlClient;


namespace HelloWorld
{

    // This is a class
    // Classes are the building blocks of C# programs
    // Classes are used to define objects
    // Classes can have properties, methods, and events
    // Classes can be instantiated to create objects
    // Classes can be inherited from other classes
    // Classes can implement interfaces
    // Classes can be sealed, which means they cannot be inherited from
    // Classes can be abstract, which means they cannot be instantiated
    // Classes can be static, which means they cannot be instantiated and cannot have instance members
    // Classes can be partial, which means they can be defined in multiple files
    // Classes can be generic, which means they can have type parameters
    // Classes can be nested, which means they can be defined within other classes
    // Classes can be used to define data structures
    // Classes can be used to define business logic
    // Classes can be used to define user interfaces
    // Classes can be used to define services
    // Classes can be used to define data access
    // Classes can be used to define utility functions
    // Classes can be used to define extension methods
    // Classes can be used to define custom attributes
    // Classes can be used to define custom exceptions
    // Classes can be used to define custom collections
    // Classes can be used to define custom delegates
    // Classes can be used to define custom events
    // Classes can be used to define custom interfaces
    // Classes can be used to define custom structs
    // Classes can be used to define custom enums
    // Classes can be used to define custom operators
    // Classes can be used to define custom conversions
    // Classes can be used to define custom indexers
    // Classes can be used to define custom properties
    // Classes can be used to define custom methods
    // Classes can be used to define custom constructors
    // Classes can be used to define custom destructors
    // Classes can be used to define custom operators
    // Classes can be used to define custom events
    // Classes can be used to define custom fields
    // Classes can be used to define custom constants
    // Classes can be used to define custom enums
    // Classes can be used to define custom structs
    // Classes can be used to define custom interfaces

    internal class Program
    {
        private static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");
            // Console.WriteLine("Hello, Mario World!");
            // Console.WriteLine(args[0]); // This will throw an exception if no arguments are passed

            // Arrays - This is a collection that has a fixed size
            // Example of an array of strings
            // string[] myGroceryArray = new string[5]; // This is an array of strings with a length of 5

            // myGroceryArray[0] = "Apples";
            // myGroceryArray[1] = "Bananas";

            // Console.WriteLine(myGroceryArray[0]); // This will print "Apples"

            // Example of an array of strings
            // string[] mySecondGroceryArray = { "Apples", "Bananas", "Oranges" }; // This is an array of strings with a length of 3
            // Console.WriteLine(mySecondGroceryArray[2]); // This will print "Oranges"

            // Lists - This is a collection that can grow or shrink in size
            // List<string> myGroceryList = new List<string>(); // This is a list of strings

            // myGroceryList.Add("Grapes");
            // myGroceryList.Add("Bananas");

            // Console.WriteLine(myGroceryList[0]); // This will print "Apples"

            // Iterating through a list
            // foreach (string item in myGroceryList)
            // {
            //     Console.WriteLine(item);
            // }

            // IEnumerable - This is an interface that allows you to iterate through a collection of items. It does not have an Add method
            // IEnumerable<string> myGroceryEnumerable = myGroceryList; // This is an IEnumerable of strings

            // Console.WriteLine(myGroceryEnumerable.First()); // This will print "Grapes"
            // Console.WriteLine(myGroceryEnumerable.ElementAt(1)); // This will print "Bananas"

            // Two-dimensional arrays
            // int[,] myTwoDimensionalArray = new int[,] {
            //     { 1, 2 },
            //     { 3, 4 }
            // }; // This is a two-dimensional array of integers

            // Console.WriteLine(myTwoDimensionalArray[0, 0]); // This will print "1"
            // Console.WriteLine(myTwoDimensionalArray[1, 1]); // This will print "4"

            // Dictionaries - This is a collection that stores key-value pairs
            // Dictionary<string, string> myGroceryDictionary = new Dictionary<string, string>(); // This is a dictionary of strings

            // myGroceryDictionary.Add("Fruit", "Apples");
            // myGroceryDictionary.Add("Vegetable", "Carrots");

            // Console.WriteLine(myGroceryDictionary["Fruit"]); // This will print "Apples"

            // Run GetSum method
            // int[] myIntArray = {13, 45, 58, 32, 58, 79};

            // int total = GetSum(myIntArray);

            // Console.WriteLine(total); // This will print "285"

            // Create an instance of the DataContext class
            DataContextDapper dapper = new DataContextDapper();

            // create a query
            string sql = "SELECT GETDATE()";

            // execute the query
            DateTime now = dapper.LoadDataSingle<DateTime>(sql);

            // print the result
            Console.WriteLine(now);

            // Create an instance of the Computer class
            Computer myComputer = new Computer()
            {
                Motherboard = "XPS 17",
                CPUCores = 7,
                HasWifi = true,
                HasLTE = true,
                ReleaseDate = new DateTime(2024, 9, 15),
                Price = 1999.99m,
                VideoCard = "Intel Iris Xe2"
            };

            // Create a query to insert the computer into the database
            // string sqlInsert = "INSERT INTO TutorialAppSchema.Computer (Motherboard, CPUCores, HasWifi, HasLTE, ReleaseDate, Price, VideoCard) VALUES (@Motherboard, @CPUCores, @HasWifi, @HasLTE, @ReleaseDate, @Price, @VideoCard)";

            // Execute the query
            // bool result = dapper.ExecuteSql(sqlInsert, myComputer);

            // Console.WriteLine(result); // This will print "1"

            // Create a query to select the computer from the database
            string sqlSelect = "SELECT * FROM TutorialAppSchema.Computer";

            // Execute the query
            IEnumerable<Computer> computersFromDatabase = dapper.LoadData<Computer>(sqlSelect);

            foreach (Computer computer in computersFromDatabase)
            {
                Console.WriteLine(computer.Motherboard); 
            }

        }
        // Methods
        // private static int GetSum(int[] ints) {
        //     int sum = 0;
        //     foreach (int i in ints) {
        //         sum += i;
        //     }
        //     return sum;
        // }
    }
}