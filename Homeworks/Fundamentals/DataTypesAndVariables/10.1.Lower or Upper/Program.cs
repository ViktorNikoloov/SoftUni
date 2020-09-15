using System;

namespace _10._1.Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            //A-Z -> 065-090
            //a-z -> 097-122
            char letter = char.Parse(Console.ReadLine());

            if (65 <= letter && letter <= 90)
            {
                Console.WriteLine("upper-case");
            }
            else if (97 <= letter && letter <= 122)
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
