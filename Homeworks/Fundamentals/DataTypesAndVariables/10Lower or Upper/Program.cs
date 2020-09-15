using System;

namespace _10Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            //A-Z -> 065-090
            //a-z -> 097-122
            char letter = char.Parse(Console.ReadLine());

            if ('A' <= letter && letter <= 'Z')
            {
                Console.WriteLine("upper-case");
            }
            else if ('a' <= letter && letter <= 'z')
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
