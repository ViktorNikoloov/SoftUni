using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class Plant
    {
        public int Rarity { get; set; }
        public List<double> Rating { get; set; }
        public Plant()
        {
            this.Rating = new List<double>() ;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] information = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries); //"{plant}<->{rarity}". 

                string name = information[0];
                int rarity = int.Parse(information[1]);

                Plant plantRarity = new Plant();
                plantRarity.Rarity = rarity;

                if (!plants.ContainsKey(name))
                {
                    plants.Add(name, plantRarity);
                }
                else
                {
                    plants[name].Rarity = rarity;
                }
            }

            string[] separators = { ": ", " - " };
            string[] command = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            while (!command.Contains("Exhibition"))
            {
                string name = command[1];
                
                if (!command.Contains("Rate") && !command.Contains("Update") && !command.Contains("Reset"))
                {
                    Console.WriteLine("error");
                }
                //if (command.Length < 3)
                //{
                //    Console.WriteLine("error");
               // }
                if (command.Contains("Rate")) // Rate: {plant} - {rating} 
                {
                    if (plants.ContainsKey(name))
                    {
                        double rating = double.Parse(command[2]);

                        plants[name].Rating.Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    
                }
                else if (command.Contains("Update")) // Update {plant} - {new_rarity} 
                {
                    if (plants.ContainsKey(name))
                    {
                        int newRarity = int.Parse(command[2]);
                    plants[name].Rarity = newRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command.Contains("Reset")) // Reset: {plant}
                {
                    if (plants.ContainsKey(name))
                    {
                        plants[name].Rating.Clear();
                    plants[name].Rating.Add(0);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                command = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in plants)
            {
                if (item.Value.Rating.Count == 0)
                {
                    item.Value.Rating.Add(0);
                }
                if (item.Value.Rarity == 0)
                {
                    item.Value.Rarity = 0;
                }
            }

            foreach (var plant in plants)
            {
                if (plant.Value.Rating.Count > 0)
                {
                    plant.Value.Rating.Add(plant.Value.Rating.Average());
                    plant.Value.Rating.RemoveRange(0, plant.Value.Rating.Count - 1);
                }
                
            }
            var sortedPlants = plants.OrderByDescending(plant => plant.Value.Rarity).ThenByDescending(plant => plant.Value.Rating.Average()).ToDictionary(item => item.Key, item => item.Value);

            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in sortedPlants)
            {
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value.Rarity}; Rating: {item.Value.Rating[0]:f2}");
            }
            //Descending(x => x.Value.Rarity).ThenBy
        }
    }
}
