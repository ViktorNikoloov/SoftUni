using System;

namespace _09._Chars_to_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char one = char.Parse(Console.ReadLine());
            char two = char.Parse(Console.ReadLine());
            char three = char.Parse(Console.ReadLine());
            string output = "";
            output += one;
            output += two;
            output += three;

            Console.WriteLine(output);
        }
    }
}
