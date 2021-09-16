using System;

namespace CarAgencyAPI.Models
{
    public class UpdateRentalDTO : CreateRentalDTO
    {
        public DateTime ReturnDate { get; set; }

        public override Rental ToRental()
        {
            var updateRental = base.ToRental();
            updateRental.ReturnDate = ReturnDate;
            return updateRental;
        }

    }
}
