using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string line = reader.ReadLine();
                int count = 0;

                while (line != null)
                {
                    if (count % 2 == 0)
                    {
                        Regex pattern = new Regex(@"[\-\,\.\!\?]");
                        var newLine = pattern.Replace(line, "@").Split().ToArray().Reverse();

                        Console.WriteLine(string.Join(" ", newLine));
                    }
                    count++;

                    line = reader.ReadLine();
                }
            }
        }
    }
}
