using System;

namespace _1._Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            //Годишната такса за тренировки по баскетбол – цяло число в интервала[0… 999]
            int yearTax = int.Parse(Console.ReadLine());

            //Calculation
            //•	Баскетболни кецове – цената им е 40% по-малка от таксата за една година
            //•	Баскетболен екип – цената му е 20 % по - евтина от тази на кецовете
            //•	Баскетболна топка – цената ѝ е 1 / 4 от цената на баскетболния екип
            //•	Баскетболни аксесоари – цената им е 1 / 5 от цената на баскетболната топка

            double shoes = yearTax * 0.6;
            double shirt = shoes * 0.8;
            double ball = shirt / 4.0;
            double ask = ball / 5.0;
            double totalSum = shoes + shirt + ball + ask + yearTax;

            //output
            Console.WriteLine($"{totalSum:f2}");

        }
    }
}
