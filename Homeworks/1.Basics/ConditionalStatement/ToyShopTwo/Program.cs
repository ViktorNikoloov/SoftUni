using System;

namespace ToyShopTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            double tripPrice = double.Parse(Console.ReadLine());
            int puzzleNum = int.Parse(Console.ReadLine());
            int dollNum = int.Parse(Console.ReadLine());
            int bearlNum = int.Parse(Console.ReadLine());
            int minionNum = int.Parse(Console.ReadLine());
            int truckNum = int.Parse(Console.ReadLine());

            //calculation
            // Пъзел - 2.60 лв.;  Говореща кукла -3 лв.;  Плюшено мече -4.10 лв.;  Миньон - 8.20 лв.;  kамионче - 2 лв.
            double toysSum = 0;
            toysSum += puzzleNum * 2.6;
            toysSum += dollNum * 3.00;
            toysSum += bearlNum * 4.10;
            toysSum += minionNum * 8.2;
            toysSum += truckNum * 2.00;
            //Console.WriteLine(toysSum);

            int toysNum = puzzleNum + dollNum + bearlNum + minionNum + truckNum;

            // toys > 50 = 25% disscount

            if (toysNum >= 50)
            {
                toysSum *= 0.75;   
            }

            // rent 10%
            toysSum *= 0.9; 

            if (toysSum >= tripPrice)
            {
                double totalSum = toysSum - tripPrice;
                Console.WriteLine($"Yes! {totalSum:f2} lv left.");
            }

            else
            {
                Console.WriteLine($"Not enough money! {tripPrice - toysSum:f2} lv needed.");
            }

        }
    }
}
