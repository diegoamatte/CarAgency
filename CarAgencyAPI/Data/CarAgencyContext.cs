using Microsoft.EntityFrameworkCore;
using CarAgencyAPI.Models;

namespace CarAgencyAPI.Data
{
    public class CarAgencyContext : DbContext
    {
        public CarAgencyContext(DbContextOptions<CarAgencyContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Rental> Rentals { get; set; }

    }
}
