using ProductShop.Data;
using ProductShop.DataTransferObjects.Input;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AutoMapper;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            InitializeMapper();

            //01.Import Users
            //var inputXml = File.ReadAllText("./Datasets/users.xml");
            //var result = ImportUsers(db, inputXml);
            //Console.WriteLine(result);

            //02.Import Products
            var inputXml = File.ReadAllText("./Datasets/products.xml");
            var result = ImportUsers(db, inputXml);
            Console.WriteLine(result);


        }

        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile<ProductShopProfile>(); });
        }

        //01.Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
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

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(), XmlRootAttribute(root));

        }

    }
}