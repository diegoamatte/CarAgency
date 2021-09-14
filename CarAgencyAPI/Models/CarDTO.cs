namespace CarAgencyAPI.Models
{
    public class CarDTO
    {
        public Brand Brand { get; set; }

        public string Model { get; set; }

        public byte Doors { get; set; }

        public string Color { get; set; }

        public Transmission Transmission { get; set; }

        public Car ToCar()
        {
            var newCar = new Car();
            newCar.Brand = Brand;
            newCar.Model = Model;
            newCar.Doors = Doors;
            newCar.Color = Color;
            newCar.Transmission = Transmission;
            return newCar;
        }

    }
}
