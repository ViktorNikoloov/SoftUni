using System;

namespace _5._Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            double savedMoney = 0;

            while (destination != "End")
            {
                double budget = double.Parse(Console.ReadLine());
                while (budget > savedMoney)
                {
                    double deposit = double.Parse(Console.ReadLine());
                    savedMoney += deposit;
                }
                if (budget <= savedMoney)
                {
                    Console.WriteLine($"Going to {destination}!");
                    savedMoney = 0;
                }
                destination = Console.ReadLine();

            }
        }
    }
}
