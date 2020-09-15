using System;

namespace FishTank2
{
    class Program
    {
        static void Main(string[] args)
        {
            double leght = double.Parse(Console.ReadLine());
            double widgh = double.Parse(Console.ReadLine());
            double hight = double.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double volume = leght * widgh * hight / 1000;
            double finalPercent = volume * percent / 100;
            double total = volume - finalPercent;
            Console.WriteLine($"{total:F3}");

        }

    }
}
