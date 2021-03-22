using AutoMapper;
using ProductShop.DataTransferObject.Product;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<User, UserInputModel>();

            CreateMap<Product, ProductInputModel>();

            CreateMap<Product, ListProductInRange>()
                .ForMember(x=>x.SellerName, y=>y.MapFrom(x=>x.Seller.FirstName + " " + x.Seller.LastName));
        }
    }
}
