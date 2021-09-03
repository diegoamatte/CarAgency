using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CarAgency.Models;
namespace CarAgency.Controllers
{
    class CarCRUD: ICRUD<Car>
    {
        private string Path;
        public CarCRUD(string path)
        {
            Path = path;
        }
        private List<Car> carList = new List<Car>();
        public Car Create(Car car)
        {
            LoadData();
            car.Id = carList.Count > 0 ? carList[carList.Count-1].Id + 1 : 0;
            carList.Add(car);
            File.WriteAllText(Path, JsonSerializer.Serialize(carList));
            return car;
        }
        public Car Get(int id)
        {
            LoadData();
            return carList.Find(car=> car.Id == id);
        }
        public void Delete(int id)
        {
            LoadData();
            if(carList.Count > id)
            {
                carList.RemoveAt(id);
                File.WriteAllText(Path, JsonSerializer.Serialize(carList));
            }
        }
        public Car Update(Car car)
        {
            Car updatedCar = null;
            if(carList.Find(x => x.Id == car.Id) != null)
            {
                LoadData();
                carList[car.Id] = car;
                File.WriteAllText(Path, JsonSerializer.Serialize(carList));
                updatedCar = car;
            }
            return updatedCar;
        }
        private void LoadData()
        {
            if (File.Exists(Path))
            {
                var carsJson = File.ReadAllText(Path);
                carList = JsonSerializer.Deserialize<List<Car>>(carsJson);
            }
        }
    }
}
