using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int seatNum = r * c;

            double premiere = 12.0;
            double normal = 7.5;
            double discount = 5.0;
            double price = 0;

            if (projection == "Premiere")
            {
                price = seatNum * premiere;
            }
            else if (projection == "Normal")
            {
                price = seatNum * normal;
            }
            else
            {
                price = seatNum * discount;
            }

            Console.WriteLine($"{price:f2}");
        }
    }
}
