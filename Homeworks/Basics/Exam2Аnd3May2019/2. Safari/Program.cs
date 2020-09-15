using System;

namespace _2._Safari
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //Бюджет – реално число
            // Колко литра гориво ще са им нужни – реално число
            //Ден от седмицата – "Saturday" и "Sunday"
            double budget = double.Parse(Console.ReadLine());
            double litresFuel = double.Parse(Console.ReadLine());
            string dayOfTheWeek = Console.ReadLine();
            double price = (litresFuel * 2.10) + 100;

            if (dayOfTheWeek == "Saturday")
            {
                price *= 0.9;
            }
            else
            {
                price *= 0.8;
            }

            if (budget >= price)
            {
                Console.WriteLine($"Safari time! Money left: {budget - price:f2} lv. ");
            }
            else
            {
                Console.WriteLine($"Not enough money! Money needed: {price - budget:f2} lv.");
            }

        }
    }
}
