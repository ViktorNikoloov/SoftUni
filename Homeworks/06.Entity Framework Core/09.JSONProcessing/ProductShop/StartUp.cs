using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using ProductShop.Models;
using ProductShop.Data;
using ProductShop.DataTransferObject.Product;
using ProductShop.DataTransferObject.UsersProducts;
using ProductShop.DataTransferObject.Category;
using ProductShop.DataTransferObject.ExportUserAndProducts;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();

            InitializeStaticMapper();

            //ResetDatabase(db);

            //02.Import Users
            //string inputJson = File.ReadAllText("../../../Datasets/users.json");
            //string result = ImportUsers(db, inputJson);
            //Console.WriteLine(result);

            //03.Import Products
            //string inputJson = File.ReadAllText("../../../Datasets/products.json");
            //string result = ImportProducts(db, inputJson);
            //Console.WriteLine(result);

            //04.Import Categories
            //string inputJson = File.ReadAllText("../../../Datasets/categories.json");
            //string result = ImportCategories(db, inputJson);
            //Console.WriteLine(result);

            //05.Import Categories and Products
            //string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");
            //string result = ImportCategoryProducts(db, inputJson);
            //Console.WriteLine(result);

            //06.Export Products in Range
            //string result = GetProductsInRange(db);
            //Console.WriteLine(result);

            //07.Export Successfully Sold Products
            //string result = GetSoldProducts(db);
            //Console.WriteLine(result);

            //08.Export Categories by Products Count
            //string result = GetCategoriesByProductsCount(db);
            //Console.WriteLine(result);

            //09.Export Users and Products
            string result = GetUsersWithProducts(db);
            Console.WriteLine(result);
        }

        /*We can use it for export*/
        private static void InitializeStaticMapper()
        {
            /*Static Mapper*/
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
        }

        /*We need to use it for import*/
        private static void InitializeInstanceMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }

        /*Delete old DB and create new one*/
        private static void ResetDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");

        }

        //02.Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeInstanceMapper();

            var dtoUsers = JsonConvert
                .DeserializeObject<IEnumerable<UserInputModel>>(inputJson);

            var users = mapper.Map<IEnumerable<UserDTO>>(dtoUsers);

            context.Users.AddRange((User)users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        //03.Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeInstanceMapper();

            IEnumerable<ProductInputModel> productsDto = JsonConvert
                 .DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);

            var products = mapper.Map<IEnumerable<ProductDTO>>(productsDto);

            context.Products.AddRange((Product)products);
            context.SaveChanges();


            return $"Successfully imported {products.Count()}";
        }

        //04.Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeInstanceMapper();

            /*First Solution*/
            //var categoriesDto = JsonConvert
            //    .DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson);

            //var categories = mapper.Map<IEnumerable<Category>>(categoriesDto);

            //foreach (var category in categories)
            //{
            //    if (category.Name != null)
            //    {
            //        context.Categories.Add(category);
            //    }
            //}
            //context.SaveChanges();

            //return $"Successfully imported {context.Categories.Count()}";

            /*Second Solution*/
            var categoriesDto = JsonConvert
                .DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson);

            var categories = mapper.Map<IEnumerable<Category>>(categoriesDto)
            .Where(n => n.Name != null)
            .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {context.Categories.Count()}";
        }

        //05.Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeInstanceMapper();

            var categoryProductsDto = JsonConvert
                .DeserializeObject<IEnumerable<CategoryProductsInput>>(inputJson);

            var categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoryProductsDto);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        //06.Export Products in Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                /*Select Solution*/
                //.Select(p => new
                //{
                //    name = p.Name,
                //    price = p.Price,
                //    seller = p.Seller.FirstName + " " + p.Seller.LastName
                //})

                /*DTO Solution*/
                //.Select(p =>  new ListProductInRange
                //{
                //    Name = p.Name,
                //    Price = p.Price,
                //    SellerName = p.Seller.FirstName + " " + p.Seller.LastName
                //})
                /*Mapper Solution*/
                .ProjectTo<ListProductInRange>()
                .ToList();



            var jsonFile = JsonConvert.SerializeObject(products, Formatting.Indented);

            return jsonFile;
        }

        //07.Export Successfully Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Count() >= 1 && u.ProductsSold.Any(x => x.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
            /*Select Solution*/
            //    .Select(u => new
            //    {
            //        firstName = u.FirstName,
            //        lastName = u.LastName,
            //        soldProducts = u.ProductsSold
            //        .Where(p => p.Buyer != null)
            //        .Select(p => new
            //        {
            //            name = p.Name,
            //            price = p.Price,
            //            buyerFirstName = p.Buyer.FirstName,
            //            buyerLastName = p.Buyer.LastName

            //        })
            //    .ToList()
            //    })
            //.ToList();

            /*DTO Solution*/
            //.Select(u => new UsersSoldProductsDTO
            //{
            //    FirstName = u.FirstName,
            //    LastName = u.LastName,
            //    SoldProducts = u.ProductsSold.Select(ps => new UserProducts
            //    {
            //        Name = ps.Name,
            //        Price = ps.Price,
            //        BuyerFirstName = ps.Buyer.FirstName,
            //        BuyerLastName = ps.Buyer.LastName
            //    })
            //    .ToList()
            //})
            //.ToList();

            /*Mapping Solution*/
            .ProjectTo<UsersSoldProductsDTO>()
            .ToList();


            var json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;
        }

        //08.Export Categories by Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var products = context
                .Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
            /*Select Solution*/
            //.Select(c => new
            //{
            //    category = c.Name,
            //    productsCount = c.CategoryProducts.Count,
            //    averagePrice = c.CategoryProducts.Average(cp => cp.Product.Price).ToString("F2"),
            //    totalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price).ToString("F2")
            //});

            /*DTO Solution*/
            //.Select(c => new CategoryByProductCountDTO
            //{
            //    Category = c.Name,
            //    ProductsCount = c.CategoryProducts.Count,
            //    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price).ToString("F2"),
            //    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price).ToString("F2")
            //});

            .ProjectTo<CategoryByProductCountDTO>()
            .ToList();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        //09.Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Include(ps => ps.ProductsSold)
                .ToList()
                .Where(u => u.ProductsSold.Count() >= 1 && u.ProductsSold.Any(b => b.BuyerId != null))
                 //.ProjectTo<UserDTO>()

                 /*Select Solution*/
                 //.Select(u => new
                 //{
                 //    firstName = u.FirstName,
                 //    lastName = u.LastName,
                 //    age = u.Age,
                 //    soldProducts = new
                 //    {
                 //        count = u.ProductsSold.Count(b => b.BuyerId != null),
                 //        products = u.ProductsSold
                 //        .Where(b => b.BuyerId != null)
                 //            .Select(ps => new
                 //            {
                 //                name = ps.Name,
                 //                price = ps.Price
                 //            })
                 //             .ToList()
                 //    }
                 //})
                 //.OrderByDescending(x => x.soldProducts.products.Count)
                 //.ToList();

                 /*DTO Solution*/
                 .Select(u => new UserDTO()
                 {
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     Age = u.Age,
                     SoldProducts = new SoldProductDTO()
                     {
                         Count = u.ProductsSold.Count(b => b.BuyerId != null),
                         Products = u.ProductsSold
                                 .ToList()
                                 .Where(b => b.BuyerId != null)
                                 .Select(ps => new ProductDTO()
                                 {
                                     Name = ps.Name,
                                     Price = ps.Price
                                 }).ToList()
                     }
                 })
                  .OrderByDescending(x => x.SoldProducts.Products.Count)
                  .ToList();


            var displayObject = new
            {
                usersCount = users.Count(),
                users = users
            };

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(displayObject, settings);

            return json;
        }

    }
}
