using CarAgencyAPI.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace CarAgencyAPI.Data
{
    public class CarCRUD : ICRUD<Car>
    {
        private readonly CarAgencyContext _context;

        public CarCRUD(CarAgencyContext context)
        {
            _context = context;
        }

        public Car Create(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return car;
        }

        public void Delete(int id)
        {
            var car = GetById(id);

            if (car is not null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }

        public Car GetById(int id)
        {
            return _context.Cars.Find(id);
        }

        public Car Update(Car car,int id)
        {
            var updatedCar = GetById(id);
            updatedCar.Brand = car.Brand;
            updatedCar.Color = car.Color;
            updatedCar.Doors = car.Doors;
            updatedCar.Transmission = car.Transmission;
            updatedCar.Model = car.Model;
            _context.SaveChanges();
            return updatedCar;
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Cars;
        }

    }
}
