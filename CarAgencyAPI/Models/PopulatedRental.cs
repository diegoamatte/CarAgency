using System;

namespace CarAgencyAPI.Models
{
    public class PopulatedRental
    {
        public int Id { get; set; }

        public short RentDays { get; set; }

        public Client Client { get; set; }

        public Car Car { get; set; }

        public DateTime ReturnDate { get; set; }

    }
}
