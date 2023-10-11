using AutoMapper;
using CRUDMVCCarsRental.Entities;
using CRUDMVCCarsRental.Models;

namespace CRUDMVCCarsRental.Mappers
{
    public class CarsRentalProfile : Profile
    {
        public CarsRentalProfile()
        {
            CreateMap<CreateCarInputModel, Car>();
            CreateMap<Car, EditCarInputModel>();
            CreateMap<Car, CarsViewModel>();

            CreateMap<Rent, RentsViewModel>();
            CreateMap<RentInputModel, Rent>();
            CreateMap<RentsViewModel, Rent>();

        }
    }
}
