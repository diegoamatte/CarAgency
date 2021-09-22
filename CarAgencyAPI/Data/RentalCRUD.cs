using CarAgencyAPI.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace CarAgencyAPI.Data
{
    public class RentalCRUD : ICRUD<Rental>
    {
        private DataManager<Rental> _data;

        private readonly ICRUD<Car> _carCrud;

        private readonly ICRUD<Client> _clientCrud;

        private IList<Rental> _rentalsList;

        public RentalCRUD(IConfiguration configuration, ICRUD<Car> carCrud, ICRUD<Client> clientCrud)
        {
            _data = new DataManager<Rental>(configuration["Paths:Rentals"]);
            _rentalsList = _data.ReadData();
            _carCrud = carCrud;
            _clientCrud = clientCrud;
        }
        public Rental Create(Rental rental)
        {
            rental.Id = _rentalsList.LastOrDefault() is not null ? _rentalsList.Last().Id + 1 : 1;
            _rentalsList.Add(rental);
            _data.SaveData(_rentalsList);
            return rental;
        }

        public void Delete(int id)
        {
            var rentalToDelete = GetById(id);
            if (rentalToDelete is not null)
            {
                _rentalsList.Remove(rentalToDelete);
                _data.SaveData(_rentalsList);
            }
        }

        public IEnumerable<Rental> GetAll()
        {
            return _rentalsList;
        }

        public Rental GetById(int id)
        {
            return _rentalsList.Where(rental => rental.Id == id).FirstOrDefault();
        }

        public Rental Update(Rental rental, int id)
        {
            rental.Id = id;
            var index = _rentalsList.IndexOf(GetById(rental.Id));
            _rentalsList[index] = rental;
            _data.SaveData(_rentalsList);
            return rental;
        }

        public PopulatedRental Populate(Rental rental)
        {
            var populated = new PopulatedRental();
            populated.Id = rental.Id;
            populated.Car = _carCrud.GetById(rental.CarID);
            populated.Client = _clientCrud.GetById(rental.ClientID);
            populated.ReturnDate = rental.ReturnDate;
            populated.RentDays = rental.RentDays;
            return populated;
        }

    }
}
