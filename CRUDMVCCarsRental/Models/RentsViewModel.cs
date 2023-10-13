using System.ComponentModel.DataAnnotations;

namespace CRUDMVCCarsRental.Models
{
    public class RentsViewModel
    {
        public Guid Id {  get; set; }
        [Display(Name = "Data de Inicio")]
        public DateTime StartingDate { get; set; }
        [Display(Name = "Data do Fim")]
        public DateTime EndingDate { get; set; }
        [Display(Name = "Valor Total")]
        public decimal Value { get; set; }
        [Display(Name = "Dias Alugado")]
        public int DaysRented { get; set; }
        public Guid CarId { get; set; }
    }
}
