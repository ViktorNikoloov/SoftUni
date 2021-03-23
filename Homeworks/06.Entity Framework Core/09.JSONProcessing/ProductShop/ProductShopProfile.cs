using AutoMapper;

using ProductShop.Models;
using ProductShop.DataTransferObject.Product;
using ProductShop.DataTransferObject.UsersProducts;
using ProductShop.DataTransferObject.Category;
using System.Linq;
using ProductShop.DataTransferObject.ExportUserAndProducts;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //02.Import Users
            CreateMap<UserInputModel, User>();

            //03.Import Products
            CreateMap<ProductInputModel, Product>();

            //04.Import Categories
            CreateMap<CategoryInputModel, Category>();

            //05.Import Categories and Products
            CreateMap<CategoryProductsInput, CategoryProduct>();

            //06.Export Products in Range
            CreateMap<Product, ListProductInRange>()
                .ForMember(x=>x.SellerName, y=>y.MapFrom(x=>x.Seller.FirstName + " " + x.Seller.LastName));

            //07.Export Successfully Sold Products
            CreateMap<User, UsersSoldProductsDTO>();

            //08.Export Categories by Products Count
            CreateMap<Category, CategoryByProductCountDTO>()
                .ForMember(cb => cb.Category, c => c.MapFrom(cn => cn.Name))
                .ForMember(cb => cb.ProductsCount, c => c.MapFrom(pc => pc.CategoryProducts.Count))
                .ForMember(cb => cb.AveragePrice, c => c.MapFrom(ap => ap.CategoryProducts.Average(p => p.Product.Price).ToString("F2")))
                .ForMember(cb => cb.TotalRevenue, c => c.MapFrom(tr => tr.CategoryProducts.Sum(tp => tp.Product.Price).ToString("F2")));

            //09.Export Users and Products
            //CreateMap<User, UserDTO>()
            // .ForMember(x => x.SoldProducts.Count, y => y.MapFrom(x => x.ProductsSold.Where(b => b.BuyerId != null).Count()))
            //    .ForMember(x => x.SoldProducts.Products, y => y.MapFrom(x => x.ProductsSold.Where(b => b.BuyerId != null)));

        }
    }
}
