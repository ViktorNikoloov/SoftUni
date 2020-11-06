using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree.Common
{
    public class Engine
    {
        private readonly ICollection<Person> people;
        private readonly ICollection<Product> products;

        public Engine()
        {
            people = new List<Person>();
            products = new List<Product>();
        }

        public void Run()
        {
            try
            {
                AddPeople();

                AddProducts();

                string[] command = Console.ReadLine()
                .Split()
                .ToArray();
                while (command[0] != "END")
                {
                    string personName = command[0];
                    string productName = command[1];

                    Person person = people.FirstOrDefault(x => x.Name == personName);
                    Product product = products.FirstOrDefault(x => x.Name == productName);

                    if (person != null && product != null)
                    {
                        string result = person.AddProduct(product);

                        Console.WriteLine(result);
                    }

                    command = Console.ReadLine()
                        .Split()
                        .ToArray();
                }

                foreach (var person in people)
                {
                    Console.WriteLine(person);
                }

            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }



        }

        private void AddProducts()
        {
            string[] allProducts = Console.ReadLine()
                            .Split(";", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();


            foreach (var productInfo in allProducts)
            {
                string[] productAdnCost = productInfo
                    .Split("=")
                    .ToArray();

                string productName = productAdnCost[0];
                decimal cost = decimal.Parse(productAdnCost[1]);

                Product product = new Product(productName, cost);
                products.Add(product);
            }
        }

        private void AddPeople()
        {
            string[] allPeople = Console.ReadLine()
                            .Split(";")
                            .ToArray();

            foreach (var peopleInfo in allPeople)
            {
                string[] nameAndMoney = peopleInfo
                    .Split("=")
                    .ToArray();

                string name = nameAndMoney[0];
                decimal money = decimal.Parse(nameAndMoney[1]);

                Person person = new Person(name, money);
                people.Add(person);

            }
        }
    }
}
