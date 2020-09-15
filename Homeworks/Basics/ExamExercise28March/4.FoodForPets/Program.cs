using System;

namespace _4.FoodForPets
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //•	Брой дни – цяло число в диапазона [1…30]
            //•	Общо количество храна – реално число в диапазона[0.00…10000.00]
            int days = int.Parse(Console.ReadLine());
            double food = double.Parse(Console.ReadLine());
            double allDogFood = 0;
            double allCatFood = 0;
            double eatenFood = 0;
            double biscuits = 0;

            //o Количество изядена храна от кучето – цяло число в диапазона[10…500]
            //o Количество изядена храна от котката – цяло число в диапазона[10…500]
            for (int i = 1; i <= days; i++)
            {
                //На всеки трети ден получават награда - бисквитки. Количеството на бисквитките е 10% от общо изядената храна за деня.

                int dogFood = int.Parse(Console.ReadLine());
                int catFood = int.Parse(Console.ReadLine());
                allDogFood += dogFood;
                allCatFood += catFood;
                eatenFood = allCatFood + allDogFood;

                if (i % 3 == 0)
                {
                    biscuits += (catFood + dogFood) * 0.1;

                }

            }

            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuits)}gr.");
            Console.WriteLine($"{(eatenFood / food) * 100:f2}% of the food has been eaten.");
            Console.WriteLine($"{(allDogFood / eatenFood) * 100:f2}% eaten from the dog.");
            Console.WriteLine($"{(allCatFood / eatenFood) * 100:f2}% eaten from the cat.");
        }
    }
}
