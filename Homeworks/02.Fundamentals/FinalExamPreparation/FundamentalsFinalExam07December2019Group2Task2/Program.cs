using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FundamentalsFinalExam07December2019Group2Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> info = new Dictionary<string, List<int>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string pattern = @"!(?<cmd>[A-Z][a-z]{2,})!:\[(?<name>[A-z]{8,})\]";

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string name = match.Groups["name"].ToString();
                    string command = match.Groups["cmd"].ToString();

                    for (int g = 0; g < name.Length; g++)
                    {
                        int num = (int)(name[g]);

                        if (!info.ContainsKey(command))
                        {

                            info.Add(command, new List<int>() { num });
                        }
                        else
                        {
                            info[command].Add(num);
                        }
                    }
                    foreach (var item in info)
                    {
                        Console.WriteLine($"{item.Key}: {string.Join(" ", item.Value)}");
                    }
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
