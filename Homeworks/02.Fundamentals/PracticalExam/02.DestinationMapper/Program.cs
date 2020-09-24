using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            MatchCollection matches = Regex.Matches(Console.ReadLine(), @"([=|\/])(?<name>[A-Z][A-z]{2,})\1");
            int points = 0;

            foreach (Match match in matches)
            {
                points += match.Groups["name"].Length;
            }
            List<string> names = new List<string>();

            foreach (Match item in matches)
            {
                names.Add(item.Groups["name"].Value);
            }
            
                Console.WriteLine($"Destinations: {string.Join(", ", names)}");
            
            Console.WriteLine($"Travel Points: {points}");
        }
    }
}
