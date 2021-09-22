using System;

namespace CarAgencyAPI.Models
{
    public class RentalDTO
    {
        public short RentDays { get; set; }

        public int ClientID { get; set; }

        public int CarID { get; set; }

        public DateTime ReturnDate { get; set; }

    }
}
