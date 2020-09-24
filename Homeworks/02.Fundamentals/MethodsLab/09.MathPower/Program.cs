using System;

namespace _09.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            double powerNumber = Power(number, power);

            Console.WriteLine(powerNumber);
        }

        static double Power(double number, double power)
        {
            double powerNumber = Math.Pow(number, power);

            return powerNumber;
        }
    }
}
