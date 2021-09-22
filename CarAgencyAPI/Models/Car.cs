using System.ComponentModel.DataAnnotations;

namespace CarAgencyAPI.Models
{
    public class Car
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public Brand Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public byte Doors { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public Transmission Transmission { get; set; }

    }
}
