using System;
using System.Text.RegularExpressions;

namespace _3.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
           var pattern = (@"(\b(?<day>\d{2})(.)(?<month>[A-Za-z]{3})\2(?<year>\d{4})\b)");

            string dates = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(dates);


           //MatchCollection dates = Regex.Matches(Console.ReadLine(), @"(\b(?<day>\d{2})(.)(?<month>[A-Za-z]{3})\2(?<year>\d{4})\b)");

            foreach (Match date in matches)
            {
                var day = date.Groups["day"].Value;
                Console.WriteLine($"Day: {day}, Month: {date.Groups["month"]}, Year: {date.Groups["year"]}");
            }
            Console.WriteLine();
        }
    }
}
