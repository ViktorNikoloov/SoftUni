using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _1.FurnitureExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> furniture = new List<string>();
            double totalPrice = 0;

            string pattern = @">>(?<name>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";

            string input = Console.ReadLine();
            while (input != "Purchase")
            {
                Regex regex = new Regex(pattern);

                Match match = regex.Match(input);
                if (match.Success)
                {
                    furniture.Add(match.Groups["name"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    double quantity = double.Parse(match.Groups["quantity"].Value);
                    totalPrice += price * quantity;
                }
                
                input = Console.ReadLine();
                
            }

            Console.WriteLine("Bought furniture:");
            if (totalPrice > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, furniture));

            }

            Console.WriteLine($"Total money spend: {totalPrice:f2}");
           
           
        }
    }
}
