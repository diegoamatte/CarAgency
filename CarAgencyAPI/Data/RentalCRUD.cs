using CarAgencyAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CarAgencyAPI.Data
{
    public class RentalCRUD : ICRUD<Rental>
    {
        private readonly CarAgencyContext _context;

        public RentalCRUD(CarAgencyContext context)
        {
            _context = context;
        }
        public Rental Create(Rental rental)
        {
            _context.Rentals.Add(rental);
            _context.SaveChanges();
            return rental;
        }

        public void Delete(int id)
        {
            var rental = GetById(id);
            if (rental is not null)
            {
                _context.Rentals.Remove(rental);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Rental> GetAll()
        {
            return _context.Rentals.Include(rental => rental.Car).Include(rental=>rental.Client);
        }

        public Rental GetById(int id)
        {
            return GetAll().Where(rental => rental.Id == id).FirstOrDefault();
        }

        public Rental Update(Rental rental, int id)
        {
            var updatedRental = GetById(id);
            updatedRental.Car = rental.Car;
            updatedRental.Client = rental.Client;
            updatedRental.RentDays = rental.RentDays;
            updatedRental.ReturnDate = rental.ReturnDate;
            _context.SaveChanges();
            return updatedRental;
        }

        public Rental DTOToRental(RentalDTO dto) =>
            new Rental
            {
                Car = _context.Cars.Find(dto.CarID),
                Client = _context.Clients.Find(dto.ClientID),
                RentDays = dto.RentDays,
                ReturnDate = dto.ReturnDate 
            };
        
    }
}
