using System;

namespace _6._VetParking
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
                double itemPrice = double.Parse(Console.ReadLine());
                if (budgetLeft > itemPrice)
                {
                    counter++;
                    if (counter % 3 == 0)
                    {
                        allMoney += (itemPrice * 1.0) / 2;
                        budgetLeft -= (itemPrice * 1.0) / 2;
                    }
                    else
                    {
                        allMoney += itemPrice;
                        budgetLeft -= itemPrice;
                    }
                    if (budgetLeft == 0)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {itemPrice - budgetLeft:f2} leva!");
                    break;
                }
                command = Console.ReadLine();

            }

            if (command == "Stop" || budgetLeft == 0)
            {
                Console.WriteLine($"You bought {counter} products for {allMoney:f2} leva.");
            }

        }
    }
}