using System;

namespace GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            //condition
            //За снимките  ще бъдат нужни определен брой статисти, облекло за всеки един статист и декор.
            //•	Декорът за филма е на стойност 10% от бюджета. 
            //•	При повече от 150 статиста,  има отстъпка за облеклото на стойност 10 %.


            //input
            // Бюджет за филма – реално число в интервала [1.00 … 1000000.00]
            // Брой на статистите – цяло число в интервала[1 … 500]
            // Цена за облекло на един статист – реално число в интервала[1.00 … 1000.00]

            double budget = double.Parse(Console.ReadLine());
            int statics = int.Parse(Console.ReadLine());
            double costumeForAllStatics = double.Parse(Console.ReadLine()) * statics;
            double decor = budget * 0.1;

            if (statics > 150)
            {
                costumeForAllStatics *= 0.9;
            }
            if (decor + costumeForAllStatics > budget )
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(decor + costumeForAllStatics) - budget:f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - (decor + costumeForAllStatics):f2} leva left.");
            }

            //output
            //	Ако парите за декора и дрехите са повече от бюджета:
            // "Not enough money!"
            // "Wingard needs {парите недостигащи за филма} leva more."
            // Ако парите за декора и дрехите са по малко или равни на бюджета:
            // "Action!"
            // "Wingard starts filming with {останалите пари} leva left."
            //Резултатът трябва да е форматиран до втория знак след десетичната запетая.






        }
    }
}
