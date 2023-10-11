namespace CRUDMVCCarsRental.Entities
{
    public class Rent
    {
        public Guid Id { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public decimal Value { get; set; }
        public int DaysRented { get; set; }
        public Guid CarId { get; set; }

        public void CalculateDaysRented()
        {
            DaysRented = (int)EndingDate.Subtract(StartingDate).TotalDays;
        }
        public void CalculateValueOfRent(decimal dayValue)
        {
            Value = DaysRented * dayValue;
        }
    }
}
