using System;

namespace InchesToSentimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            double inch = double.Parse(Console.ReadLine());
            double sent = inch * 2.54;
            Console.WriteLine(sent);
        }
    }
}
