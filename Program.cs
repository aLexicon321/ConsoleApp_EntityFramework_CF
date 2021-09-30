using Microsoft.EntityFrameworkCore;
using System;

namespace ConsoleApp_EntityFramework_CF
{
    // Packages To Add
    // EntityFrameworkCore
    // EntityFrameworkCore.Tools
    // EntityFrameworkCore.SqlServer

    // Commands to execute in Package Manager Console
    // Add-Migration Initial
    // Update-Database

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console App - EntityFramework/CF");
            Console.WriteLine("\n\n- Press enter to add a <Car> to DB");

            try
            {
                VehicleContext db = new VehicleContext();
                Car newCar = new("Saab", "95 Turbo", 2002, 210);
                db.Cars.Add(newCar);
                db.SaveChanges();
                Console.WriteLine("<Car> was added to DB");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Failed to save <Car> to DB\nErr: {ex}");
            }
            finally
            {
                Console.ReadLine();
            }   
        }
    }

    class Car
    {
        public Car(string brand, string model, int year, int speed)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Speed = speed;
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Speed { get; set; }
    }

    class VehicleContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vehicle_EF_CF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
