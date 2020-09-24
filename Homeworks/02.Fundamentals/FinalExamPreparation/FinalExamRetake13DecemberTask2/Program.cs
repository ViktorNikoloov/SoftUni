using System;
using System.ComponentModel.Design.Serialization;
using System.Text.RegularExpressions;

namespace FinalExamRetake13DecemberTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Match match = Regex.Match(Console.ReadLine(), @"(.+)>([0-9]{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})+<\1");
                string password = string.Empty;

                if (match.Success)
                {
                    password += match.Groups[2].Value + match.Groups[3].Value + match.Groups[4].Value + match.Groups[5].Value;
                    Console.WriteLine($"Password: {password}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }

        }
    }
}
