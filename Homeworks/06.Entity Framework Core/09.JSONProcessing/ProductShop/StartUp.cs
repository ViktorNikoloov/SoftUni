using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();

            //ResetDatabase(db);

            ////02.Import Users
            //string inputJson = File.ReadAllText("../../../Datasets/users.json");
            //string result = ImportUsers(db, inputJson);
            //Console.WriteLine(result);

            //03.Import Products
            string inputJson = File.ReadAllText("../../../Datasets/products.json");
            string result = ImportProducts(db, inputJson);
            Console.WriteLine(result);
        }

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
            User[] users = JsonConvert
                .DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        //03.Import Products
        static string ImportProducts(ProductShopContext context, string inputJson)
        {
            Product[] products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();


            return $"Successfully imported {products.Length}";
        }
    }
}