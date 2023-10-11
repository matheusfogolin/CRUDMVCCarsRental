namespace CRUDMVCCarsRental.Models
{
    public class CreateCarInputModel
    {
        public string Model { get; set; }
        public int FabricationYear { get; set; }
        public int ModelYear { get; set; }
        public string Engine { get; set; }
        public decimal RentValuePerDay { get; set; }
    }
}
