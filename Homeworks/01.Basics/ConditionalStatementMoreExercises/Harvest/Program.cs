using System;

namespace Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            //От лозе с площ X квадратни метри се
            //заделя 40% от реколтата за производство
            //на вино. От 1 кв.м лозе се изкарват Y
            //килограма грозде. За 1 литър вино са 
            //нужни 2,5 кг. грозде. Желаното количество
            //вино за продан е Z литра.
            //Напишете програма, която пресмята колко вино 
            //може да се произведе и дали това количество е 
            //достатъчно. Ако е достатъчно, остатъкът се разделя
            //по равно между работниците на лозето.

            //Input
            //1ви ред: X кв.м е лозето – цяло число в интервала [10 … 5000]
            //2ри ред: Y грозде за един кв.м – реално число в интервала [0.00 … 10.00]
            //3ти ред: Z нужни литри вино – цяло число в интервала [10 … 600]
            //4ти ред: брой работници – цяло число в интервала [1 … 20]
            int wineyard = int.Parse(Console.ReadLine());
            double grape = double.Parse(Console.ReadLine());
            int litres = int.Parse(Console.ReadLine());
            int employee = int.Parse(Console.ReadLine());
            // Calculation
            double harvest = wineyard * grape;
            double production = harvest * 0.4;
            double wineLitres = production / 2.5;
            //output
            //Ако произведеното вино е по-малко от нужното:
            if (wineLitres < litres)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(litres - wineLitres)} liters wine needed.");
            }
            //Резултатът трябва да е закръглен към по-ниско цяло число
            //Ако произведеното вино е повече от нужното:
            else
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wineLitres)} liters.");
                //Резултатът трябва да е закръглен към по-ниско цяло число
                Console.WriteLine($"{Math.Ceiling(wineLitres - litres)} liters left -> {Math.Ceiling((wineLitres - litres) / employee)} liters per person.");
            }
        }
    }
}
