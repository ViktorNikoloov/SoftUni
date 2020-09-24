using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0;
            
            if (flower == "Roses")
            {
                if (number > 80)
                {
                    price = number * 5 * 0.9;
                }
                else
                {
                    price = number * 5;
                }
            }
            else if (flower == "Dahlias")
            {
                if (number > 90)
                {
                    price = number * 3.8 * 0.85;
                }
                else
                {
                    price = number * 3.8;
                }
            }
            else if (flower == "Tulips")
            {
                if (number > 80)
                {
                    price = number * 2.8 * 0.85;
                }
                else
                {
                    price = number * 2.8;
                }
            }
            else if (flower == "Narcissus")
            {
                if (number < 120)
                {
                    price = number * 3 * 1.15;
                }
                else
                {
                    price = number * 3;
                }
            }
            else if (flower == "Gladiolus")
            {
                if (number < 80)
                {
                    price = number * 2.5 * 1.20;
                }
                else
                {
                    price = number * 2.5;
                }
            }

            if (budget >= price)
            {
                Console.WriteLine($"Hey, you have a great garden with {number} {flower} and {budget - price:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {price - budget:f2} leva more.");
            }
        }
    }
}
