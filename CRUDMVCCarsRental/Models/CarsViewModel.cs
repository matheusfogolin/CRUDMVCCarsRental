using System.ComponentModel.DataAnnotations;

namespace CRUDMVCCarsRental.Models
{
    public class CarsViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Data de Registro")]
        public DateTime RegistrationDate { get; set; }
        [Display(Name = "Modelo")]
        public string Model { get; set; }
        [Display(Name = "Ano de Fabricação")]
        public int FabricationYear { get; set; }
        [Display(Name = "Ano do Modelo")]
        public int ModelYear { get; set; }
        [Display(Name = "Potência do Motor")]
        public string Engine { get; set; }
        [Display(Name = "Valor do Aluguel Diário")]
        public decimal RentValuePerDay { get; set; }
        [Display(Name = "Alugado")]
        public bool Rented { get; set; }
        [Display(Name = "Deletado")]
        public bool Deleted { get; set; }
    }
}
