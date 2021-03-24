using AutoMapper;
using CarDealer.DTO.SalesDTOs;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<ImportCustomersDto, Customer>();
        }
    }
}
