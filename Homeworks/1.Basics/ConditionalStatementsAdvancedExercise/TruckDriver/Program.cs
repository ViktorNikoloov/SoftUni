using System;

namespace TruckDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Първи ред – Сезон – текст "Spring", "Summer", "Autumn" или "Winter"
            //•	Втори ред –  Километри на месец – реално число в интервала[10.00...20000.00
            string season = Console.ReadLine();
            double kmMonth = double.Parse(Console.ReadLine());
            double price = 0;

            // 1 season = 4 months !

            if (kmMonth <= 5000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    price = kmMonth * 0.75;
                }

                else if (season == "Summer")
                {
                    price = kmMonth * 0.9;
                }

                else if (season == "Winter")
                {
                    price = kmMonth * 1.05;
                }
            }

            else if (kmMonth <= 10000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    price = kmMonth * 0.95;
                }

                else if (season == "Summer")
                {
                    price = kmMonth * 1.10;
                }

                else if (season == "Winter")
                {
                    price = kmMonth * 1.25;
                }
            }

            else
            {
                    price = kmMonth * 1.45;
            }

            double selary = (price * 4) * 0.9;

            Console.WriteLine($"{selary:f2}");
        }
    }
}
