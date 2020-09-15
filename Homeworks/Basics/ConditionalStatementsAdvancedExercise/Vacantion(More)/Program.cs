using System;

namespace Vacantion_More_
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Първи ред – Бюджет – реално число в интервала [10.00...10000.00]
            //•	Втори ред –  Сезон – текст "Summer" или "Winter"
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "";
            string place = "";
            double price = 0;

            if (budget <= 1000)
            {
                place = "Camp";

                if (season == "Summer")
                {
                    destination = "Alaska";
                    price = budget * 0.35;
                }

                else
                {
                    destination = "Morocco";
                    price = budget * 0.55;
                }
            }

            else if (budget <= 3000)
            {
                place = "Hut";

                if (season == "Summer")
                {
                    destination = "Alaska";
                    price = budget * 0.20;
                }

                else
                {
                    destination = "Morocco";
                    price = budget * 0.40;
                }
            }

            else if (budget > 3000)
            {
                place = "Hotel";

                if (season == "Summer")
                {
                    destination = "Alaska";
                    price = budget * 0.1;
                }

                else
                {
                    destination = "Morocco";
                    price = budget * 0.1;
                }
            }

            Console.WriteLine($"{destination} - {place} - {budget - price:f2}");
        }
    }
}
