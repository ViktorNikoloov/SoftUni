using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FinalExamRetake13DecemberТаск2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                

                Match match = Regex.Match(Console.ReadLine(), @"\|(?<name>[A-Z]{4,})\|:#(?<title>[A-Za-z]+ [A-za-z]+)#");
                if (match.Success)
                {
                    Console.WriteLine(@$"{match.Groups["name"].Value}, The {match.Groups["title"].Value}
>> Strength: {match.Groups["name"].Value.Count()}
>> Armour: {match.Groups["title"].Value.Count()}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
