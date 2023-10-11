using CRUDMVCCarsRental.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUDMVCCarsRental.Data.DbConfiguration
{
    public class RentDbConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder
                .ToTable("Rents");
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.StartingDate)
                .HasColumnType("datetime")
                .HasColumnName("Starting_Date");
            builder
                .Property(x => x.EndingDate)
                .HasColumnType("datetime")
                .HasColumnName("Ending_Date");
            builder
                .Property(x => x.Value)
                .HasColumnType("money");
            builder
                .Property(x => x.DaysRented)
                .HasColumnType("int")
                .HasColumnName("Days_Rented");
        }
    }
}
