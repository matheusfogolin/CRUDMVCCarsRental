using CRUDMVCCarsRental.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CRUDMVCCarsRental.Data
{
    public class CarsRentalDbContext : DbContext
    {
        public CarsRentalDbContext(DbContextOptions<CarsRentalDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Rent> Rents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
