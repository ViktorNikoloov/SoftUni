using System;

namespace Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input
            //брой дни – цяло число в интервал [1…5000]
            //оставена храна в килограми – цяло число в интервал [0…100000]
            //храна на ден за кучето в килограми – реално число в интервал [0.00…100.00]
            //храна на ден за котката в килограми– реално число в интервал [0.00…100.00]
            //храна на ден за костенурката в грамове – реално число в интервал [0.00…10000.00]
            int days = int.Parse(Console.ReadLine());
            int foodLeft = int.Parse(Console.ReadLine());
            double dog = double.Parse(Console.ReadLine());
            double cat = double.Parse(Console.ReadLine());
            double turtle = double.Parse(Console.ReadLine()) / 1000;
            //Calculation
            double eatenFood = 0;
            eatenFood = (dog + cat + turtle) * days;
            if (foodLeft >= eatenFood)
            {
                Console.WriteLine($"{Math.Floor(foodLeft - eatenFood)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(eatenFood - foodLeft)} more kilos of food are needed.");
            }
        }
    }
}
