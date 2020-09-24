using System;

namespace _03.CharactersinRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());

            Console.WriteLine(TheCharsBetween(end, start));
        }

        static string TheCharsBetween(char one, char two)
        {
            string output = "";
            if (one < two)
            {
                for (int i = one + 1; i < two; i++)
                {
                    output += (char)i + " ";
                }
            }
            else
            {
                for (int i = two + 1; i < one; i++)
                {
                    output += (char)i + " ";
                }
            }

            return output;
        }
    }
}
