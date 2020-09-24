using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //conditional
            //С парите, които ще спечели иска да отиде на екскурзия. Да се напише програма, която пресмята печалбата от поръчката.
            //Ако поръчаните играчки са 50 или повече магазинът прави отстъпка 25% от общата цена. От спечелените пари Петя трябва да даде 10% за наема на магазина. 
            //Да се пресметне дали парите ще ѝ стигнат да отиде на екскурзия.

            // input
            //1.Цена на екскурзията -реално число в интервала[1.00 … 10000.00]
            //2.Брой пъзели - цяло число в интервала[0… 1000]
            //3.Брой говорещи кукли -цяло число в интервала[0 … 1000]
            //4.Брой плюшени мечета -цяло число в интервала[0 … 1000]
            //5.Брой миньони - цяло число в интервала[0 … 1000]
            //6.Брой камиончета - цяло число в интервала[0 … 1000]
            double tripPrice = double.Parse(Console.ReadLine());
            int puzzelNumber = int.Parse(Console.ReadLine());
            int dollNumber = int.Parse(Console.ReadLine());
            int bearNumber = int.Parse(Console.ReadLine());
            int minionNumber = int.Parse(Console.ReadLine());
            int truckNumber = int.Parse(Console.ReadLine());

            // calculation
            //Цени на играчките:  Пъзел - 2.60 лв.; Говореща кукла -3 лв.; Плюшено мече -4.10 лв.; Миньон - 8.20 лв.; Камионче - 2 лв.
            double profit = 0;
            profit += puzzelNumber * 2.6;
            profit += dollNumber * 3.00;
            profit += bearNumber * 4.10;
            profit += minionNumber * 8.20;
            profit += truckNumber * 2.00;
            double toysNumber = puzzelNumber + dollNumber + bearNumber + minionNumber + truckNumber;

            
            if (toysNumber >= 50)
            {
                profit *= 0.75;
            }
            if (profit >= tripPrice)
            {
                double rent = profit * 0.1;
                Console.WriteLine($"Yes! {profit - rent - tripPrice:F2} lv left.");
            }
            else
            {
                double rent = profit * 0.1;
                double totalSum = profit - rent;

                Console.WriteLine($"Not enough money! {tripPrice - totalSum :F2} lv needed.");
            }





        }
    }
}
