using System;

namespace Three
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	На първи ред получавате тип цвете: string ["Sunflower", "Daisy", "Lavender", "Mint"].
            //•	На втори ред получавате брой цветя: цяло число[1 - 1000].
            //•	На трети ред получавате сезон: string["Spring", "Summer", "Autumn"].
            string flowerType = Console.ReadLine();
            int flowersNum = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double honey = 0;

            //calculation
            switch (season)
            {
                case "Spring":
                    switch (flowerType)
                    {
                        case "Sunflower":
                        case "Mint":
                            honey = flowersNum * 10;
                            break;

                        case "Daisy":
                        case "Lavender":
                            honey = flowersNum * 12;
                            break;
                    }
                    break;

                case "Summer":
                    switch (flowerType)
                    {
                        case "Sunflower":
                        case "Daisy":
                        case "Lavender":
                            honey = flowersNum * 8;
                            break;

                        case "Mint":
                            honey = flowersNum * 12;
                            break;
                    }
                    break;

                case "Autumn":
                    switch (flowerType)
                    {
                        case "Sunflower":
                            honey = flowersNum * 12;
                            break;

                        case "Daisy":
                        case "Lavender":
                        case "Mint":
                            honey = flowersNum * 6;
                            break;
                    }
                    break;

            }

            //•	Ако сезонът е "Summer", кошерът произвежда 10% повече мед.
            //•	Ако сезонът е "Autumn", кошерът произвежда 5 % по - малко мед.
            //•	Ако сезонът е "Spring", цветовете на "Daisy" и "Mint" дават 10 % повече.
            if (season == "Summer")
            {
                honey *= 1.10;
            }
            else if (season == "Autumn")
            {
                honey *= 0.95;
            }
            else if (season == "Spring" && (flowerType == "Daisy" || flowerType == "Mint"))
            {
                honey *= 1.10;
            }

            Console.WriteLine($"Total honey harvested: {honey:f2}");

        }
    }
}
