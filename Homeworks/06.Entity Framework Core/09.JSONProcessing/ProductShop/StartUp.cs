﻿using System;
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

            ////04.Import Categories
            //string inputJson = File.ReadAllText("../../../Datasets/categories.json");
            //string result = ImportCategories(db, inputJson);
            //Console.WriteLine(result);

            ////05.Import Categories and Products
            //string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");
            //string result = ImportCategoryProducts(db, inputJson);
            //Console.WriteLine(result);

            ////06.Export Products in Range
            string result = GetSoldProducts(db);

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

        //04.Import Categories
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

        //06.Export Products in Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .ToList();

            var jsonFile = JsonConvert.SerializeObject(products, Formatting.Indented);

            return jsonFile;
        }

        //07.Export Successfully Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            //Get all users who have at least 1 sold item with a buyer.
            //Order them by last name, then by first name. 
            //Select the person's first and last name.
            //For each of the sold products (products with buyers), select the product's name, price and the buyer's first and last name.

            var users = context
                .Users
                .Where(u => u.ProductsSold.Count() >= 1 && u.ProductsSold.Any(x=>x.Buyer != null))

                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                    .Where(p=>p.Buyer != null)
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName

                    })
                    .ToList()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;
        }
    }
}