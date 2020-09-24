using System;
using System.Collections.Generic;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string[] input = Console.ReadLine().Split();
            while (input[0] != "buy")
            {
                string name = input[0];
                double price = double.Parse(input[1]);
                int quantity = int.Parse(input[2]);
                
                Product product = new Product(name, quantity, price);

                if (!products.ContainsKey(name))
                {
                    products.Add(name, product);
                }
                else
                {
                    products[name].Price = price;
                    products[product.Name].Quantity += quantity; // test !
                }

                input = Console.ReadLine().Split();
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {products[product.Key].Price * products[product.Key].Quantity:f2}");
            }
        }
    }

    public class Product
    {
        public string Name{get; set;}
        public int Quantity { get; set; }
        public double Price { get; set; }
        
        

        public Product(string name, int quantity, double price)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
        }

        //public int Quantity
        //{
        //    get
        //    {
        //        return quantity;
        //    }
        //    set
        //    {
        //        quantity = value;
        //    }
        //}

        //public double Price
        //{
        //    get
        //    {
        //        return price;
        //    }
        //    set
        //    {
        //        price = value;
        //    }
        //}
    }
}
