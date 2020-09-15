using System;

namespace _05.AddandSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numThree = int.Parse(Console.ReadLine());

            double sum = Sum(numOne, numTwo);
            double subtract = Subtract(sum, numThree);

            Console.WriteLine(subtract);
        }

        static double Sum(double one, double two)
        {
            double sum = one + two;
            return sum;
        }

        static double Subtract(double one, double two)
        {
            double sum = one - two;
            return sum;
        }
    }
}

