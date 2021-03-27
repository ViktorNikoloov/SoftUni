using AutoMapper;
using ProductShop.DataTransferObjects.Input;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<ImportUserModel, User>();

            CreateMap<ImportProductModel, Product>();
        }
    }
}
