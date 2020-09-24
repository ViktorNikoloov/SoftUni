using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = Factorial(double.Parse(Console.ReadLine()));
            double secondNum = Factorial(double.Parse(Console.ReadLine()));
            double result = Devision(firstNum, secondNum);

            Console.WriteLine($"{result:f2}");
        }

        static double Factorial(double number)
        {
            double factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        static double Devision(double first, double second)
        {
            double devision = first / second;
            return devision;
        }
    }
}
