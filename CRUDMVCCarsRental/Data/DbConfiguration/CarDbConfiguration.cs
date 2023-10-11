using CRUDMVCCarsRental.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUDMVCCarsRental.Data.DbConfiguration
{
    public class CarDbConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder) 
        {
            builder
                .ToTable("Cars");
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.RegistrationDate)
                .HasColumnType("datetime")
                .HasColumnName("Registration_Date");
            builder
                .Property(x => x.Model)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);
            builder
                .Property(x => x.FabricationYear)
                .HasColumnType("int")
                .HasColumnName("Fabrication_Year");
            builder
                .Property(x => x.ModelYear)
                .HasColumnType("int")
                .HasColumnName("Model_Year");
            builder
                .Property(x => x.Engine)
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);
            builder
                .Property(x => x.RentValuePerDay)
                .HasColumnType("money")
                .HasColumnName("Rent_Value_Per_Day");
            builder
                .Property(x => x.Deleted)
                .HasColumnType("bit");
            builder
                .HasMany(x => x.Rents)
                .WithOne()
                .HasForeignKey(y => y.CarId);
        }
    }
}
