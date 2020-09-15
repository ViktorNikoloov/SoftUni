using System;

namespace _2._EasterGuests
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //На първия ред са броят на гостите – цяло число в интервала [0 ... 200000]
            //На втория ред е бюджетът с който разполага Любо  – цяло число в интервала [0 ... 200000]
            int numberOfGuests = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            //output
            //1 козунак стига за 3 човека
            //всеки гост ще получи и по 2 яйца
            //Един козунак струва 4лв.
            //Едно яйце струва 0.45лв.

            double neededBread = Math.Ceiling((double)numberOfGuests / 3);
            double neededEggs = numberOfGuests * 2;
            double breadPrice = neededBread * 4.00;
            double eggsPrice = neededEggs * 0.45;
            double totalPrice = breadPrice + eggsPrice;

            //output
            if (budget >= totalPrice)
            {
                Console.WriteLine($"Lyubo bought {neededBread} Easter bread and {neededEggs} eggs.");
                Console.WriteLine($"He has {budget - totalPrice:f2} lv. left.");
            }
            else
            {
                Console.WriteLine("Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {totalPrice - budget:f2} lv. more.");
            }
        }
    }
}
