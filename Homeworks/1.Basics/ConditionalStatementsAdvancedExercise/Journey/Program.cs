using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = Double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double price = 0;
            string destination = "";
            string place = "";

            // Calculation
            if (budget <= 100)
            {
                switch (season)
                {
                    case "summer":
                        destination = "Bulgaria";
                        price = budget * 0.3;
                        place = "Camp";
                        break;

                    case "winter":
                        destination = "Bulgaria";
                        price = budget * 0.7;
                        place = "Hotel";
                        break;
                }
            }

            else if (budget <= 1000)
            {
                switch (season)
                {
                    case "summer":
                        destination = "Balkans";
                        price = budget * 0.4;
                        place = "Camp";
                        break;

                    case "winter":
                        destination = "Balkans";
                        price = budget * 0.8;
                        place = "Hotel";
                        break;
                }
            }

            else
            {
                switch (season)
                {
                    case "summer":
                    case "winter":
                        destination = "Europe";
                        price = budget * 0.9;
                        place = "Hotel";
                        break;
                }
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{place} - {price:f2}");
        }
    }
}
