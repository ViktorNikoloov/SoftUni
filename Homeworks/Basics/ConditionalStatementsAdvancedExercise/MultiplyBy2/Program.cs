using System;

namespace MultiplyBy2
{
    class Program
    {
        static void Main(string[] args)
        {
            

            while (true)
            {
                double numbers = double.Parse(Console.ReadLine());

                do
                {
                    Console.WriteLine($"Result: {numbers * 2:f2}");
                } while (true);
                
            }
        }
    }
}
