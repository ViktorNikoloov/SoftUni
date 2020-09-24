using System;

namespace _5.CareOfPuppy
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Закупеното количество храна за кученцето в килограми – цяло число в интервала [1 …100]
            int purchasedFood = int.Parse(Console.ReadLine()) * 1000;
            string adopted = Console.ReadLine();
            int foodPerDay = 0;
            //а всеки следващ ред до получаване на команда Adopted ще получавате колко грама изяжда кученцето на всяко хранене - цяло число в интервала [10 …1000]

            while (adopted != "Adopted")
            {
                foodPerDay += int.Parse(adopted);
                adopted = Console.ReadLine();
            }

            if (foodPerDay <= purchasedFood)
            {
                Console.WriteLine($"Food is enough! Leftovers: {purchasedFood - foodPerDay} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {foodPerDay - purchasedFood} grams more.");

            }

        }
    }
}
