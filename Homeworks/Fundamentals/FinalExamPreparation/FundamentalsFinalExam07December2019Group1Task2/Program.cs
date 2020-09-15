using System;
using System.Text.RegularExpressions;

namespace FundamentalsFinalExam07December2019Group1Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int successfulRegistrationsCount = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match matchName = Regex.Match(input, @"(U\$)(?<username>[A-Z][a-z]{2,})\1");
                Match matchPass = Regex.Match(input, @"(P\@\$)(?<password>[A-z]{5,}\d+)\1");

                if (matchName.Success && matchPass.Success)
                {
                    Console.WriteLine(@$"Registration was successful
Username: {matchName.Groups["username"]}, Password: {matchPass.Groups["password"]}");
                    successfulRegistrationsCount++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {successfulRegistrationsCount}");
        }
    }
}
