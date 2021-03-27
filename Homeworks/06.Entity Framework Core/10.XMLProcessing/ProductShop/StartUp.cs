using ProductShop.Data;
using ProductShop.DataTransferObjects.Input;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AutoMapper;
using ProductShop.Models;
using System.Collections;
using System.Collections.Generic;
using ProductShop.DataTransferObjects.Output;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();


            //01.Import Users
            //var inputXml = File.ReadAllText("./Datasets/users.xml");
            //var result = ImportUsers(db, inputXml);
            //Console.WriteLine(result);

            //02.Import Products
            //var inputXml = File.ReadAllText("./Datasets/products.xml");
            //var result = ImportProducts(db, inputXml);
            //Console.WriteLine(result);

            //03.Import Categories
            //var inputXml = File.ReadAllText("./Datasets/categories.xml");
            //var result = ImportCategories(db, inputXml);
            //Console.WriteLine(result);

            //05.Products In Range
            //var result = GetProductsInRange(db);
            //Console.WriteLine(result);

            //06.Sold Products
            var result = GetProductsInRange(db);
            Console.WriteLine(result);

        }

        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile<ProductShopProfile>(); });
        }

        //01.Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            //Because of Judge
            InitializeMapper();

            const string root = "Users";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserModel[]), new XmlRootAttribute(root));

            var textReader = new StringReader(inputXml);

            var usersDto = xmlSerializer
                .Deserialize(textReader) as ImportUserModel[];
            var mapUser = Mapper.Map<User[]>(usersDto);

            context.Users.AddRange(mapUser);
            context.SaveChanges();

            return $"Successfully imported {mapUser.Count()}";
        }

        //02.Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string root = "Products";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductModel[]), new XmlRootAttribute(root));

            var textReader = new StringReader(inputXml);

            var productsDto = xmlSerializer.Deserialize(textReader) as ImportProductModel[];

            var products = productsDto
                .Select(p => new Product()
                {
                    Name = p.Name,
                    Price = p.Price,
                    SellerId = p.SellerId,
                    BuyerId = p.BuyerId
                })
                .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //03.Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string root = "Categories";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryModel[]), new XmlRootAttribute(root));

            var textReader = new StringReader(inputXml);

            var categoriesDto = xmlSerializer.Deserialize(textReader) as ImportCategoryModel[];

            var categories = categoriesDto
                .Where(c => c.Name != null)
                .Select(c => new Category()
                {
                    Name = c.Name
                })
                .ToList();

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}"; ;
        }

        //04.Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string root = "CategoryProducts";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoriesProductsModel[]), new XmlRootAttribute(root));

            var textReader = new StringReader(inputXml);

            var categoriesProductsDto = xmlSerializer
                .Deserialize(textReader) as ImportCategoriesProductsModel[];

            var categories = context.Categories.ToList();
            var products = context.Products.ToList();

            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();
            foreach (var categoryProductDto in categoriesProductsDto)
            {
                if (context.Categories.Any(x => x.Id == categoryProductDto.CategoryId) &&
                    context.Products.Any(x => x.Id == categoryProductDto.ProductId))
                {
                    var categoriesProducts = new CategoryProduct()
                    {
                        CategoryId = categoryProductDto.CategoryId,
                        ProductId = categoryProductDto.ProductId
                    };

                    categoryProducts.Add(categoriesProducts);
                }

            }

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";


        }

        //05.Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            const string root = "Products";

            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductInRangeModel()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductInRangeModel[]), new XmlRootAttribute(root));

            var textWriter = new StringWriter();

            var nameSpace = new XmlSerializerNamespaces();
            nameSpace.Add("", "");

            xmlSerializer.Serialize(textWriter, products, nameSpace);

            var result = textWriter.ToString();

            return result;
        }

        //06.Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {

        }
    }

}
