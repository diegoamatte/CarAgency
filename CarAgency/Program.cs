using CarAgency.Controllers;
using CarAgency.Models;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace CarAgency
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
            IConfiguration config = builder.Build();
            var settings = config.GetSection("Settings").Get<Settings>();
            var crud = new CarCRUD(settings.Path);
            ShowCrudMenu();
            GetUserInput();    
        }
        
        private static void ShowCrudMenu()
        {
            string options = @"Welcome to Car Agency Software
Select your option:
1. Create a car.
2. Get a car
3. Update a car
4. Delete a car
5. Exit";
            Console.WriteLine(options);
        }

        private static void GetUserInput()
        {
            var key = Console.ReadLine();
            switch(key)
            {
                case "1":
                    //CreateCar();
                    break;
                case "2":
                    //ShowCar();
                    break;
                case "3":
                    //UpdateCar();
                    break;
                case "4":
                    //DeleteCar();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }


    }
}