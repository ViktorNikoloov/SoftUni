using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalExam04April2020Group1Task2
{
    class Target
    {
        public int Population { get; set; }
        public int Gold { get; set; }
        public Target(int population, int gold)
        {
            this.Population = population;
            this.Gold = gold;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Target> targets = new Dictionary<string, Target>();

            string[] cities = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);
            while (!cities.Contains("Sail"))
            {
                string city = cities[0];
                Target target = new Target(int.Parse(cities[1]), int.Parse(cities[2]));

                if (!targets.ContainsKey(city))
                {
                    targets.Add(city, target);
                }
                else
                {
                    targets[city].Population += int.Parse(cities[1]);
                    targets[city].Gold += int.Parse(cities[2]);
                }

                cities = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);
            }

            string[] command = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            while (!command.Contains("End"))
            {
                string town = command[1];

                if (command.Contains("Plunder")) //Plunder=>{town}=>{people}=>{gold}
                {
                    int people = int.Parse(command[2]);
                    int gold = int.Parse(command[3]);

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                    targets[town].Gold -= gold;
                    targets[town].Population -= people;

                    if (0 >= targets[town].Gold || targets[town].Population <= 0)
                    {
                        targets.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                if (command.Contains("Prosper")) //Prosper=>{town}=>{gold}
                {
                    int gold = int.Parse(command[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        targets[town].Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {targets[town].Gold} gold.");
                    }
                }

                command = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }
            if (targets.Keys.Count != 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {targets.Keys.Count} wealthy settlements to go to:");

                foreach (var town in targets.OrderByDescending(x => x.Value.Gold).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{town.Key} -> Population: {town.Value.Population} citizens, Gold: {town.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
