using System;

namespace _2._Easter_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //Брой гости – цяло число в интервала [1...99] 
            //Цена на куверт за един човек – реално число в интервала [0.00 … 99.00]
            //Бюджетът на Деси  – реално число в интервала [0.00 … 9999.00] 
            int numberOfGuests = int.Parse(Console.ReadLine());
            double priceOfCover = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            double coverDiscount = priceOfCover;

            //calculation
            //Между 10 (вкл.) и 15 (вкл.) човека -> 15 % отстъпка от куверта за един човек
            //Между 15 и 20 (вкл.) човека -> 20 % отстъпка от куверта за един човек
            //Над 20 човека -> 25 % отстъпка от куверта за един човек
            double cake = budget * 0.10;
            if (10 <= numberOfGuests && numberOfGuests <= 15)
            {
                coverDiscount = priceOfCover * 0.85;
            }
            else if (15 < numberOfGuests && numberOfGuests <= 20)
            {
                coverDiscount = priceOfCover * 0.80;
            }
            else if (numberOfGuests > 20)
            {
                coverDiscount = priceOfCover * 0.75;
            }

            double totalSum = (numberOfGuests * coverDiscount) + cake;

            //output
            if (budget >= totalSum)
            {
                Console.WriteLine($"It is party time! {budget - totalSum:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"No party! {totalSum - budget:f2} leva needed.");
            }

        }
    }
}
