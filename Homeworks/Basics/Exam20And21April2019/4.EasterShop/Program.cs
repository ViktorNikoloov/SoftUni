using System;

namespace _4.EasterShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int EggsInTheStore = int.Parse(Console.ReadLine());
            int leftEggs = EggsInTheStore;
            int buyEggs = 0;
            bool isClose = false;
            string closeTheStore = Console.ReadLine();

            while (true)
            {
                string buyOrFill = closeTheStore;
                if (buyOrFill == "Close")
                {
                    isClose = true;
                    break;
                }

                int numberOfEggs = int.Parse(Console.ReadLine());
                if (buyOrFill == "Fill")
                {
                    leftEggs += numberOfEggs;
                }
                if (leftEggs < numberOfEggs)
                {
                    break;
                }
                if (buyOrFill == "Buy")
                {
                    leftEggs -= numberOfEggs;
                    buyEggs += numberOfEggs;
                    if (leftEggs <= 0)
                    {
                        leftEggs = 0;
                        break;
                    }
                }
                closeTheStore = Console.ReadLine();
            }

            if (isClose)
            {
                Console.WriteLine("Store is closed!");
                Console.WriteLine($"{buyEggs} eggs sold.");
            }
            else
            {
                Console.WriteLine("Not enough eggs in store!");
                Console.WriteLine($"You can buy only {leftEggs}.");
            }

        }
    }
}
