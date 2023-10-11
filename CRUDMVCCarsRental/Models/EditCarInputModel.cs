using System.ComponentModel.DataAnnotations;

namespace CRUDMVCCarsRental.Models
{
    public class EditCarInputModel
    {
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime RegistrationDate { get; set; }
        public string Model { get; set; }
        public int FabricationYear { get; set; }
        public int ModelYear { get; set; }
        public string Engine { get; set; }
        public decimal RentValuePerDay { get; set; }
        public bool Rented { get; set; }
    }
}
