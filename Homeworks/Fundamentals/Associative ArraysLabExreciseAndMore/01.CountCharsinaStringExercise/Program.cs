using System;
using System.Collections.Generic;

namespace _01.CountCharsinaStringExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> chars = new Dictionary<char, int>();
            string input = Console.ReadLine();

            foreach (var item in input)
            {
                if (item == ' ')
                {
                    continue;
                }
                else if (!chars.ContainsKey(item))
                {
                    chars.Add(item, 1);
                }
                else
                {
                    chars[item]++;
                }


            }

            foreach (var item in chars)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }

    }
}
