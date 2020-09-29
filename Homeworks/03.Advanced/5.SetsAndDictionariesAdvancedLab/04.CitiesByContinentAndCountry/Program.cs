using System;
using System.Collections.Generic;

namespace _04.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!continents.ContainsKey(continent))
                {
                    continents[continent] = new Dictionary<string, List<string>>();
                    continents[continent].Add(country, new List<string>() { city });
                }
                else if (!continents[continent].ContainsKey(country))
                {
                    continents[continent].Add(country, new List<string>() { city });
                }
                else
                {
                    continents[continent][country].Add(city);
                }
            }

            foreach(var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach(var countries in continent.Value)
                {
                    Console.WriteLine($"{countries.Key} -> {string.Join(", ", countries.Value)}");
                }
            }
        }
    }
}
