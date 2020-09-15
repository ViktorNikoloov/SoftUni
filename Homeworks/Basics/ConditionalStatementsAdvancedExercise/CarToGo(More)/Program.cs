using System;

namespace CarToGo_More_
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Първи ред – Бюджет – реално число в интервала [10.00...10000.00]
            //•	Втори ред –  Сезон – текст "Summer" или "Winter"
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double price = 0;
            string car = "";
            string carClass = "";


            if (0 < budget && budget <= 100)
            {
                carClass = "Economy class";

                if (season == "Summer")
                {
                    car = "Cabrio";
                    price = budget * 0.65;
                }

                else if (season == "Winter")
                {
                    car = "Jeep";
                    price = budget * 0.35;
                }

            }

            else if (budget <= 500)
            {
                carClass = "Compact class";

                if (season == "Summer")
                {
                    car = "Cabrio";
                    price = budget * 0.55;
                }

                else if (season == "Winter")
                {
                    car = "Jeep";
                    price = budget * 0.2;
                }

            }

            else if (budget > 500)
            {
                carClass = "Luxury class";

                if (season == "Summer" || season == "Winter")
                {
                    car = "Jeep";
                    price = budget * 0.1;
                }

            }

            Console.WriteLine(carClass);
            Console.WriteLine($"{car} - {budget - price:f2}");
            
        }
    }
}
