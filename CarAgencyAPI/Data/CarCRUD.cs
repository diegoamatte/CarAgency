using CarAgencyAPI.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace CarAgencyAPI.Data
{
    public class CarCRUD : ICRUD<Car>
    {
        private DataManager<Car> data;
        public CarCRUD(IConfiguration configuration)
        {
             data = new DataManager<Car>(configuration["Paths:Cars"]);
        }

        public Car Create(Car car)
        {
            return data.Save(car);
        }

        public void Delete(int id)
        {
            var cars = data.GetItems();
        }

        public Car Get(int id)
        {
            return data.GetItem(id);
        }

        public Car Update(Car car)
        {
            return data.UpdateItem(car,car.Id);
        }

        public IEnumerable<Car> GetAll()
        {
            return data.GetItems();
        }
    }
}
