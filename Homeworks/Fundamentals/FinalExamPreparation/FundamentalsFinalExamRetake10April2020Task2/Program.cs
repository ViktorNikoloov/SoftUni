using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FundamentalsFinalExamRetake10April2020Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            MatchCollection matches = Regex.Matches(Console.ReadLine(), @"([@,#])(?<first>[A-z]{3,})\1\1(?<second>[A-z]{3,})\1");
            List<string> pairs = new List<string>();

            foreach (Match match in matches)
            {
                string first = match.Groups["first"].ToString();
                string second = match.Groups["second"].ToString();
                string reversed = new string(second.Reverse().ToArray());

                if (matches.Count > 0)
                {
                    if (first == reversed)
                    {
                        pairs.Add($"{first} <=> {second}");
                    }
                    
                }
                

            }
            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
                if (pairs.Count > 0)
                {
                    Console.Write(@$"The mirror words are:
{string.Join(", ", pairs)}");
                }
                else
                {
                Console.WriteLine("No mirror words!");

                }
            }
            else
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
