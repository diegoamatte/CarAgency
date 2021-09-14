using System;

namespace CarAgencyAPI.Models
{
    public class Rental
    {
        public int Id { get; set; }

        public TimeSpan RentDuration { get; set; }

        public Client RentClient { get; set; }

        public Car RentedCar { get; set; }

        public DateTime ReturnDate { get; set; }

    }
}
