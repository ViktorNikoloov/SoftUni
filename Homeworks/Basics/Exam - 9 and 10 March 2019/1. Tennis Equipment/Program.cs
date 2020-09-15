using System;

namespace _1._Tennis_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Цена на една тенис ракета – реално число в интервала [0.00…100000.00]
            //•	Брой тенис ракети - цяло число в интервала[0…100]
            //•	Брой чифтове маратонки - цяло число в интервала[0…100]
            double tennisRacket = double.Parse(Console.ReadLine());
            int numbersOfRacket = int.Parse(Console.ReadLine());
            int shoes = int.Parse(Console.ReadLine());

            //calculation
            //друга екипировка, на стойност 20% от общата цена на закупените ракети и маратонки.
            //•	1 чифт маратонки = 1/6 от цената на една тенис ракета
            double racketsPrice = numbersOfRacket * tennisRacket;
            double shoesPrice = (tennisRacket / 6.0) * shoes;
            double otherThings = (racketsPrice + shoesPrice) * 0.2;
            double totalPrice = racketsPrice + shoesPrice + otherThings;

            //output    
            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(totalPrice / 8.0)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling((totalPrice * 7.0) / 8.0)}");
            

        }
    }
}
