using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
           // 1.Дължина в см – цяло число в интервала[10 … 500]
//2.Широчина в см – цяло число в интервала[10 … 300]
//3.Височина в см – цяло число в интервала[10… 200]
//4.Процент  – реално число в интервала[0.000 … 100.000]

                //int put

            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int hight = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double litres = length *width *hight * 0.001;
            double finalPercent = percent * 0.01;
            double finalLitres = litres * (1 - finalPercent);
            Console.WriteLine("{0:F3}", finalLitres);

        }
    }
}
