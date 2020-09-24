using System;

namespace _1._FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int chickenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int veganMenu = int.Parse(Console.ReadLine());

            double delivery = 2.50;
            double chickenPrice = chickenMenu * 10.35;
            double fishPrice = fishMenu * 12.40;
            double veganPrice = veganMenu * 8.15;
            double desert = (chickenPrice + fishPrice + veganPrice) * 0.20;
            double totalPrice = chickenPrice + fishPrice + veganPrice + desert + delivery;

            Console.WriteLine($"Total: {totalPrice:f2}");
        }
    }
}
