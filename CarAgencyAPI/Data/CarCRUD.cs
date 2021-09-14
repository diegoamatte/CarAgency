using CarAgencyAPI.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace CarAgencyAPI.Data
{
    public class CarCRUD : ICRUD<Car>
    {
        private DataManager<Car> data;
        private IList<Car> carsList;
        public CarCRUD(IConfiguration configuration)
        {
             data = new DataManager<Car>(configuration["Paths:Cars"]);
             carsList = data.ReadData();
        }

        public Car Create(Car car)
        {
            carsList.Add(car);
            Save();
            return car;
        }

        public void Delete(int id)
        {
            var carToDelete = carsList.Where(car => car.Id == id).FirstOrDefault();
            carsList.Remove(carToDelete);
            Save();
        }

        public Car GetById(int id)
        {
            return carsList.Where(car => car.Id == id).FirstOrDefault();
        }

        public Car Update(Car car)
        {
            var carIndex = carsList.IndexOf(GetById(car.Id));
            carsList[carIndex] = car;
            Save();
            return car;
        }

        public IList<Car> GetAll()
        {
            return carsList;
        }

        private void Save()
        {
            data.SaveData(carsList);
        }
    }
}
