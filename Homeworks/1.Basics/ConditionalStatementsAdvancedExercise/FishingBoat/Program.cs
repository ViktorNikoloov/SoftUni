using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            // Бюджет на групата – цяло число в интервала[1…8000]
            // Сезон –  текст: "Spring", "Summer", "Autumn", "Winter"
            // Брой рибари – цяло число в интервала[4…18]
    
            int budjet = int.Parse(Console.ReadLine());
            string seasons = Console.ReadLine();
            int fisherMen = int.Parse(Console.ReadLine());
            double price = 0;
            

            //Цената за наем на кораба през:
            //пролетта е  3000 лв. / лятото и есента е  4200 лв / зимата е  2600 лв.

            //до 6 човека включително  –  отстъпка от 10 %. / от 7 до 11 човека включително  –  отстъпка от 15 %. / от 12 нагоре  –  отстъпка от 25 %.

            //5% отстъпка, ако са четен брой освен ако не е есен 
            // "Spring", "Summer", "Autumn", "Winter"

            if (seasons == "Spring")
            {
                if (fisherMen <= 6)
                {
                    price = 3000 * 0.9;
                }
                else if (fisherMen <= 11)
                {
                    price = 3000 * 0.85;
                }
                else
                {
                    price = 3000 * 0.75;
                }
            }

            else if (seasons == "Summer" || seasons == "Autumn")
            {
                if (fisherMen <= 6)
                {
                    price = 4200 * 0.9;
                }
                else if (fisherMen <= 11)
                {
                    price = 4200 * 0.85;
                }
                else
                {
                    price = 4200 * 0.75;
                }
            }

            else
            {
                if (fisherMen <= 6)
                {
                    price = 2600 * 0.9;
                }
                else if (fisherMen <= 11)
                {
                    price = 2600 * 0.85;
                }
                else
                {
                    price = 2600 * 0.75;
                }
            }

            if ((seasons == "Spring" || seasons == "Summer" || seasons ==  "Winter") && fisherMen % 2 == 0)
            {
                price *= 0.95;
            }

            if (budjet >= price)
            {
                Console.WriteLine($"Yes! You have {budjet - price:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {price - budjet:f2} leva.");
            }

        }
    }
}
