using System.ComponentModel.DataAnnotations;

namespace CRUDMVCCarsRental.Entities
{
    public class Car
    {
        public Car()
        {
            Deleted = false;
        }
        public Guid Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime RegistrationDate { get; set; }
        public string Model { get; set; }
        public int FabricationYear { get; set; }
        public int ModelYear { get; set; }
        public string Engine { get; set; }
        public decimal RentValuePerDay { get; set; }
        public bool Deleted { get; set; }
        public List<Rent> Rents { get; set; }

        public void Update(DateTime registrationDate, string model, int fabricationYear, int modelYear, decimal rentValuePerDay, string engine)
        {
            RegistrationDate = registrationDate;
            Model = model;
            FabricationYear = fabricationYear;
            ModelYear = modelYear;
            Engine = engine;
            RentValuePerDay = rentValuePerDay;
        }

        public void Delete()
        {
            Deleted = true;
        }
    }
}
