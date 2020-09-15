using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FinalExamRetake15August2020Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            MatchCollection matches = Regex.Matches(Console.ReadLine(), @"([\||\#])(?<food>[A-Z][a-z]+\s{0,1}[A-z][a-z]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d{1,5})\1");

            List<string> info = new List<string>();
            int totalCalories = 0;

            foreach (Match match in matches)
            {
                totalCalories += int.Parse(match.Groups["calories"].ToString());

            }
           
            Console.WriteLine($"You have food to last you for: {totalCalories/2000} days!");
            foreach (Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups["food"].ToString()}, Best before: {match.Groups["date"].ToString()}, Nutrition: {match.Groups["calories"].ToString()}");
            }
        }
    }
}
