using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalExamRetake13DecemberTask3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> heroes = new Dictionary<string, List<string>>();

            string[] command = Console.ReadLine().Split();
            while (!command.Contains("End"))
            {
                string name = command[1];
                if (command.Contains("Enroll"))
                {
                    if (!heroes.ContainsKey(name))
                    {
                        heroes.Add(name, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already enrolled.");
                    }
                }
                else if (command.Contains("Learn"))
                {
                    string spell = command[2];

                    if (!heroes.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} doesn't exist.");
                    }
                    else if (heroes[name].Contains(spell))
                    {
                        Console.WriteLine($"{name} has already learnt {spell}.");
                    }
                    else
                    {
                        heroes[name].Add(spell);
                    }
                }
                else if (command.Contains("Unlearn"))
                {
                    string spell = command[2];

                    if (!heroes.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} doesn't exist.");
                    }
                    else if (!heroes[name].Contains(spell))
                    {
                        Console.WriteLine($"{name} doesn't know {spell}.");
                    }
                    else
                    {
                        heroes[name].Remove(spell);
                    }
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine("Heroes:");
            foreach (var hero in heroes.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"== {hero.Key}: {string.Join(", ", hero.Value)}");
            }

        }
    }
}
