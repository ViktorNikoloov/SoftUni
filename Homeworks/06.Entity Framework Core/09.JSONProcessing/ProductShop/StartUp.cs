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

            ////03.Import Products
            //string inputJson = File.ReadAllText("../../../Datasets/products.json");
            //string result = ImportProducts(db, inputJson);
            //Console.WriteLine(result);

            ////4.Import Categories
            //string inputJson = File.ReadAllText("../../../Datasets/categories.json");
            //string result = ImportCategories(db, inputJson);
            //Console.WriteLine(result);

            ////4.Import Categories and Products
            string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");
            string result = ImportCategoryProducts(db, inputJson);
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
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            Product[] products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();


            return $"Successfully imported {products.Length}";
        }

        //4.Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            /*First Solution*/
            //List<Category> categories = JsonConvert
            //    .DeserializeObject<List<Category>>(inputJson);

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
            List<Category> categories = JsonConvert
                .DeserializeObject<List<Category>>(inputJson)
                .Where(n => n.Name != null)
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {context.Categories.Count()}";
        }

        //05.Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            CategoryProduct[] categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";

        }
    }
}