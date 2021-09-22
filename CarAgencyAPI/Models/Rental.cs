using System;
using System.ComponentModel.DataAnnotations;

namespace CarAgencyAPI.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public short RentDays { get; set; }

        [Required]
        public Client Client { get; set; }

        [Required]
        public Car Car { get; set; }

        public DateTime ReturnDate { get; set; }

    }
}
