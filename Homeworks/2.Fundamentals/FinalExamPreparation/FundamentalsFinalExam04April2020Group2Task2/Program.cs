using System;
using System.Text.RegularExpressions;

namespace FundamentalsFinalExam04April2020Group2Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Match match = Regex.Match(Console.ReadLine(), @"(\@\#+)(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])\@\#+");
                string group = string.Empty;

                if (match.Success)
                {
                    string barcode = match.Groups["barcode"].Value;

                    for (int g = 0; g < barcode.Length; g++)
                    {
                        if (char.IsDigit(barcode[g]))
                        {
                            group += barcode[g];
                        }
                    }
                    if (group != string.Empty)
                    {
                        Console.WriteLine($"Product group: {group}");
                    }
                    else
                    {
                        Console.WriteLine("Product group: 00");

                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
                
            }
        }
    }
}
