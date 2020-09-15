using System;
using System.Collections.Generic;
using System.Linq;

namespace _07DecemberGroup2Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();
            int unliked = 0;

            string[] command = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);
            while (!(command.Contains("Stop")))
            {
                string guest = command[1];
                string meal = command[2];

                if (command.Contains("Like"))
                {
                    if (!(guests.ContainsKey(guest)))
                    {
                        guests.Add(guest, new List<string>() {meal});
                    }
                    else
                    {
                        if (!(guests[guest].Contains(meal)))
                        {
                            guests[guest].Add(meal);
                        }
                    }
                }
                else
                {
                    if (!(guests.ContainsKey(guest)))
                    {
                        Console.WriteLine($"{guest} is not at the party.");

                    }
                    else if (!(guests[guest].Contains(meal)))
                    {
                        Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                    }
                    else
                    {
                        guests[guest].Remove(meal);
                        unliked++;

                        Console.WriteLine($"{guest} doesn't like the {meal}.");
                    }
                }

                command = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);

            }

            foreach (var guest in guests.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{guest.Key}: {string.Join(", ", guest.Value)}".Trim());
            }

            Console.WriteLine($"Unliked meals: {unliked}");
        }
    }
}
