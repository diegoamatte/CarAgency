namespace CarAgencyAPI.Models
{
    public class Car
    {
        public int Id { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public byte Doors { get; set; }
        public string Color { get; set; }
        public Transmission Transmission { get; set; }
    }
}
