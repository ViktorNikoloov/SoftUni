using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //1.Броят на дните, в които тече кампанията – цяло число в интервала[0 … 365]
            //2.Броят на сладкарите – цяло число в интервала[0 … 1000]
            //3.Броят на тортите – цяло число в интервала[0… 2000]
            //4.Броят на гофретите – цяло число в интервала[0 … 2000]
            //5.Броят на палачинките – цяло число в интервала[0 … 2000]

            double days = double.Parse(Console.ReadLine());
            double chefs = double.Parse(Console.ReadLine());
            double cakes = double.Parse(Console.ReadLine());
            double goffrets = double.Parse(Console.ReadLine());
            double panecakes = double.Parse(Console.ReadLine());

            // Calculation
            // Торта - 45 лв.
            //•	Гофрета - 5.80 лв.
            //•	Палачинка – 3.20 лв.
            //1 / 8 от крайната сума ще бъде използвана за покриване на разходите 
            //за продуктите по време на кампанията. Да се напише програма, която изчислява сумата, 
            // която е събрана в края на кампанията.

            double cakesSum = cakes * 45.00;
            double goffretsSum = goffrets * 5.80;
            double panecakesSum = panecakes * 3.20;
            double total = ((cakesSum + goffretsSum + panecakesSum) * days) * chefs;

            double costs = total / 8;

            // Output
            // Парите, които са събрани, форматирани до втория знак след десетичната запетая.
            Console.WriteLine($"{total - costs:F2}");

        }
    }
}
