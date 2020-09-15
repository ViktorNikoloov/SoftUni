using System;

namespace Transport_Price
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input
            //Първият ред съдържа числото n – брой километри – цяло число в интервала [1…5000]
            //Вторият ред съдържа дума “day” или “night” – пътуване през деня или през нощта
            int km = int.Parse(Console.ReadLine());
            string dayOrNight = Console.ReadLine();


            //Calculation
            //Влак. Дневна / нощна тарифа: 0.06 лв. / км. 
            //Може да се използва за разстояния минимум 100 км.
            if (km >= 100)
            {
                Console.WriteLine($"{km * 0.06:f2}");
            }
            //Автобус. Дневна / нощна тарифа: 0.09 лв. / км. 
            //Може да се използва за разстояния минимум 20 км.
            else if (km >= 20)
            {
                Console.WriteLine($"{km * 0.09:f2}");
            }
            //Такси. Начална такса: 0.70 лв. 
            //Дневна тарифа: 0.79 лв. 
            // км. Нощна тарифа: 0.90 лв. / км.
            if (km < 20)
            {
                if (dayOrNight == "day")
                {
                    Console.WriteLine($"{0.7 + (km * 0.79):f2}");
                }
                else
                {
                    Console.WriteLine($"{0.7 + (km * 0.90):f2}");
                }
            }
        }
    }
}
