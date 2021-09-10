using System;
using CarAgency.Models;
using CarAgency.Controllers;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CarAgency.UI
{
    public class AgencyUI
    {
        private CarCRUD Crud;
        public AgencyUI()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
            IConfiguration config = builder.Build();
            var settings = config.GetSection("Settings").Get<Settings>();
            Crud = new CarCRUD(settings.Path);
        }
        public void ShowCrudMenu()
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
        public void GetUserInput()
        {
            var key = Console.ReadLine();
            Console.Clear();
            switch (key)
            {
                case "1":
                    CreateCar();
                    break;
                case "2":
                    ShowCar();
                    break;
                case "3":
                    UpdateCar();
                    break;
                case "4":
                    DeleteCar();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
            Console.Clear();
        }
        private void CreateCar()
        {
            Crud.Create(InputData());
        }
        private Car ShowCar()
        {
            string text = @"Input the car ID:";
            Console.WriteLine(text);
            var car = GetCarByUserInput();
            string carText = "";
            if (car != null) 
            {
                carText += @$"Id: {car.Id}
Brand: {car.Brand}
Model: {car.Model}
Doors: {car.Doors}
Color: {car.Color}
Transmission: {car.Transmission}";
            }
            else 
            {
                carText += "Car not found";
            }
            Console.WriteLine(carText);
            Console.ReadKey();
            return car;
        }
        private void UpdateCar()
        {
            string text = @"Input the car ID:";
            Console.WriteLine(text);
            var car = GetCarByUserInput();
            if(car!=null)
            {
                int id = car.Id;
                car = InputData();
                car.Id = id;
                Crud.Update(car);
            }
        }
        private void DeleteCar()
        {
            var deleteText = "Input the Car Id to delete:";
            Console.WriteLine(deleteText);
            var car = GetCarByUserInput();
            Crud.Delete(car.Id);
        }
        private Car InputData()
        {
            var options = "Select a brand:\n";
            foreach (var brand in Enum.GetValues(typeof(Brand)))
            {
                options += $"{(int)brand}.{brand}\n";
            };
            Console.WriteLine(options);
            Car car = new Car();
            int selectedBrand = Int32.Parse(Console.ReadLine());
            car.Brand = (Brand)(Enum.IsDefined(typeof(Brand), selectedBrand) ? selectedBrand : 1);
            Console.WriteLine("Input model:");
            car.Model = Console.ReadLine();
            Console.WriteLine("Input color");
            car.Color = Console.ReadLine();
            Console.WriteLine("Input doors quantity");
            car.Doors = byte.Parse(Console.ReadLine());
            Console.WriteLine("Input transmission type:");
            var transmissionType = "Select transmission type:\n";
            foreach (var trans in Enum.GetValues(typeof(Transmission)))
            {
                transmissionType += $"{(int)trans}.{trans}\n";
            };
            Console.WriteLine(transmissionType);
            var transmission = Int32.Parse(Console.ReadLine());
            car.Transmission = (Transmission)(Enum.IsDefined(typeof(Transmission), transmission) ? transmission : 1);
            return car;
        }
        private Car GetCarByUserInput()
        {
            Car car;
            try
            {
                var id = Int32.Parse(Console.ReadLine());
                car = Crud.Get(id);
            }
            catch (FormatException)
            {
                //If format fails, returns car with invalid Id to not affect crud operations.
                Console.WriteLine("Invalid ID format");
                car = new Car();
                car.Id = -1;
            }
            return car;
        }
    }
}
