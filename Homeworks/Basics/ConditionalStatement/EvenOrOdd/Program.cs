using System;

namespace EvenOrOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            //Conditional
            //Да се напише програма, която чете цяло число въведено от потребителя и отпечатва на конзолата, дали е четно или нечетно. 
            int number = int.Parse(Console.ReadLine());
           
            // Calculation
            if (number % 2 == 0)
            {
                Console.WriteLine("even");
            }
            else 
            {
                Console.WriteLine("odd");
            }
        }
    }
}
