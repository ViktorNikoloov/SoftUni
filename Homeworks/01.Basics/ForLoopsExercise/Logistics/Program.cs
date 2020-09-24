using System;

namespace Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            // На първия ред – броя на товарите за превоз – цяло число в интервала [1...1000]
            //За всеки един товар на отделен ред – тонажа на товара – цяло число в интервала[1...1000]

            int count = int.Parse(Console.ReadLine());

            int allTons = 0;
            int busTons = 0;
            int truckTons = 0;
            int trainTons = 0;

            int busPrice = 0;
            int truckPrice = 0;
            int trainPrice = 0;

            for (int i = 0; i < count; i++)
            {
                int tons = int.Parse(Console.ReadLine());
                allTons += tons;

                //•	До 3 тона – микробус(200 лева на тон)
                //•	От 4 до 11 тона – камион(175 лева на тон)
                //•	12 и повече тона – влак(120 лева на тон)
                if (0 <= tons && tons <= 3)
                {
                    busTons += tons;
                    busPrice += tons * 200;
                }
                else if (tons <= 11)
                {
                    truckTons += tons;
                    truckPrice += tons * 175;
                }
                else
                {
                    trainTons += tons;
                    trainPrice += tons * 120;
                }

            }

            double middleSum = (1.0 * busPrice + truckPrice + trainPrice) / allTons;


            //•	Първи ред – средната цена на тон превозен товар(закръглена до втория знак след дес. запетая);
            Console.WriteLine("{0:F2}", middleSum);
            //•	Втори ред – процентът тона превозвани с микробус(процент между 0.00 % и 100.00 %);
            Console.WriteLine("{0:f2}%", 1.0 * busTons / allTons * 100);
            //•	Трети ред – процентът тона превозвани с камион(процент между 0.00 % и 100.00 %);
            Console.WriteLine($"{1.0 * truckTons / allTons * 100:f2}%");
            //•	Четвърти ред – процентът тона превозвани с влак(процент между 0.00 % и 100.00 %).
            Console.WriteLine($"{1.0 * trainTons / allTons * 100:f2}%");

        }
    }
}
