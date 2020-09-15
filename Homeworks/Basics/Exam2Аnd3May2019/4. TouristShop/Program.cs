using System;

namespace _4._TouristShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double budgetLeft = budget;
            double allMoney = 0;
            int counter = 0;
            string command = Console.ReadLine();

            while (command != "Stop")
            {
                counter++;
                double itemPrice = double.Parse(Console.ReadLine());

                if (counter % 3 == 0)
                {
                    itemPrice *= 0.5;
                }
                if (budgetLeft < itemPrice)
                {
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {itemPrice - budgetLeft:f2} leva!");
                    break;
                }

                allMoney += itemPrice;
                budgetLeft -= itemPrice;

                command = Console.ReadLine();

            }

            if (command == "Stop")
            {
                Console.WriteLine($"You bought {counter} products for {allMoney:f2} leva.");
            }

        }
    }
}
