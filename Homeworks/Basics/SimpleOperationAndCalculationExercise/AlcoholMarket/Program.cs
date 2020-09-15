using System;

namespace AlcoholMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //1.Цена на уискито в лева – реално число в интервала[0.00 … 10000.00]
            //2.Количество на бирата в литри – реално число в интервала[0.00 … 1 0000.00]
            //3.Количество на виното в литри – реално число в интервала[0.00 … 10000.00]
            //4.Количество на ракията в литри – реално число в интервала[0.00 … 10000.00]
            //5.Количество на уискито в литри – реално число в интервала[0.00 … 10000.00]
            Console.Write("Whisky price: ");
            double whiskyPrice = double.Parse(Console.ReadLine()); //lv./l
            Console.Write("Beer litrers: ");
            double beerLitrers = double.Parse(Console.ReadLine());
            Console.Write("Wine litrers: ");
            double wineLitrers = double.Parse(Console.ReadLine());
            Console.Write("Rakia litres: ");
            double rakiaLitres = double.Parse(Console.ReadLine());
            Console.Write("Whsky litres: ");
            double whiskyLitres = double.Parse(Console.ReadLine());

            // Calculation
            // цената на ракията е на половина по - ниска от тази на уискито;
            // цената на виното е с 40 % по - ниска от цената на ракията;
            // цената на бирата е с 80 % по - ниска от цената на ракията.

            double rakiaPrice = whiskyPrice / 2;
            double winePrice = rakiaPrice * (1 - 0.4);
            double beerPrice = rakiaPrice * (1 - 0.8);
            double sumNeeded = (beerLitrers * beerPrice) + (wineLitrers * winePrice) + (rakiaLitres * rakiaPrice) + (whiskyLitres * whiskyPrice);

            //Output
            //•	парите, които са необходими на Пешо, форматирани до втория знак след десетичната запетая.
            Console.Write("Sum needed: ");
            Console.WriteLine("{0:F2} lv.", sumNeeded);



        }
    }
}
