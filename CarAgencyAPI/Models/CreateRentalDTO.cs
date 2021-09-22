namespace CarAgencyAPI.Models
{
    public class CreateRentalDTO
    {
        public short RentDays { get; set; }

        public int ClientID { get; set; }

        public int CarID { get; set; }

        public virtual Rental ToRental()
        {
            var newRental = new Rental();
            newRental.ClientID = ClientID;
            newRental.CarID = CarID;
            newRental.RentDays = RentDays;
            return newRental;
        }
    }
}
