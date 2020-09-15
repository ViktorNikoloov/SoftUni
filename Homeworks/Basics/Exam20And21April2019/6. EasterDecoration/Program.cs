using System;

namespace _6._EasterDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Брои на клиентите в магазина – цяло число [1… 100]
            int costumers = int.Parse(Console.ReadLine());
            double currentPrice = 0;
            double totalPrice = 0;
            int counterPurchese = 0;
            for (int i = 0; i < costumers; i++)
            {
                //Покупката която клиента е избрал – текст("basket", "wreath" или "chocolate bunny")
                string purchase = Console.ReadLine();
                while (purchase != "Finish")
                {
                    //(basket) – 1.50 лв.
                    //(wreath) – 3.80 лв.
                    //(chocolate bunny) – 7 лв.
                    counterPurchese++;
                    if (purchase == "basket")
                    {
                        currentPrice += 1.50;
                    }
                    if (purchase == "wreath")
                    {
                        currentPrice += 3.80;
                    }
                    if (purchase == "chocolate bunny")
                    {
                        currentPrice += 7.00;
                    }

                    purchase = Console.ReadLine();
                }
                if (counterPurchese % 2 == 0)
                {
                    currentPrice *= 0.8;
                }

                Console.WriteLine($"You purchased {counterPurchese} items for {currentPrice:f2} leva.");
                totalPrice += currentPrice;
                currentPrice = 0;
                counterPurchese = 0;
            }

            Console.WriteLine($"Average bill per client is: {totalPrice / costumers:f2} leva.");
        }
    }
}
