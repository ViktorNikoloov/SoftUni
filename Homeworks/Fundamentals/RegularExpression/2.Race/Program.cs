using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace _2.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string, int> asd = participants.ToDictionary(x => x, x => 0);

            string wordsPattern = @"[A-Za-z]";
            string digitsPattern = @"[0-9]";

            string input = Console.ReadLine();
            while (input != "end of race")
            {
                var nameMatch = Regex.Matches(input, wordsPattern);
                var kmMatch = Regex.Matches(input,digitsPattern);

                string name = string.Concat(nameMatch);
                int sum = kmMatch.Select(x => int.Parse(x.Value)).Sum();

                if (asd.ContainsKey(name))
                {
                    asd[name] += sum;
                }

                input = Console.ReadLine();
            }

            var output = asd.OrderByDescending(x => x.Value).ToList();

            
                Console.WriteLine($"1st place: {output[0].Key}");
                Console.WriteLine($"2nd place: {output[1].Key}");
                Console.WriteLine($"3rt place: {output[2].Key}");



        }
    }
}
