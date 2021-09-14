using CarAgencyAPI.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace CarAgencyAPI.Data
{
    public class CarCRUD : ICRUD<Car>
    {
        private DataManager<Car> _data;

        private IList<Car> _carsList;

        public CarCRUD(IConfiguration configuration)
        {
             _data = new DataManager<Car>(configuration["Paths:Cars"]);
             _carsList = _data.ReadData();
        }

        public Car Create(Car car)
        {
            _carsList.Add(car);
            _data.SaveData(_carsList);
            return car;
        }

        public void Delete(int id)
        {
            var carToDelete = _carsList.Where(car => car.Id == id).FirstOrDefault();
            _carsList.Remove(carToDelete);
            _data.SaveData(_carsList);
        }

        public Car GetById(int id)
        {
            return _carsList.Where(car => car.Id == id).FirstOrDefault();
        }

        public Car Update(Car car,int id)
        {
            var carIndex = _carsList.IndexOf(GetById(car.Id));
            _carsList[carIndex] = car;
            _data.SaveData(_carsList);
            return car;
        }

        public IEnumerable<Car> GetAll()
        {
            return _carsList;
        }

    }
}
