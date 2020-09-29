using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> stores = new Dictionary<string, Dictionary<string, double>>();

            string[] input = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries); //"{shop}, {product}, {price}".  
            while (input[0] != "Revision")
            {
                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (!stores.ContainsKey(shop))
                {
                    stores[shop] = new Dictionary<string, double>();
                    stores[shop].Add(product, price);
                }
                else
                {
                    stores[shop].Add(product, price);
                }

                input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            var sortedStores = stores.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            foreach (var store in sortedStores)
            {
                Console.WriteLine($"{store.Key}->");

                foreach (var product in store.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
