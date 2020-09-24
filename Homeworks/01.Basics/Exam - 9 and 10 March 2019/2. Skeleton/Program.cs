using System;

namespace _2._Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ред 1.Минути на контролата – цяло число в интервала [0…59]
            // Ред 2.Секунди на контролата – цяло число в интервала[0…59]
            //Ред 3.Дължината на улея в метри – реално число в интервала[0.00…50000]
            //Ред 4.Секунди за изминаване на 100 метра – цяло число в интервала[0…1000]

            double recordMin = double.Parse(Console.ReadLine());
            double recordSec = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double newTime = double.Parse(Console.ReadLine());

            //calculation
            //на всеки 120 метра неговото време намаля с 2.5 секунди.
            double oldRecord = (recordMin * 60) + recordSec;
            double delay = (length / 120) * 2.5;
            double newRecord = (length / 100) * newTime - delay;

            //output
            if (newRecord <= oldRecord)
            {
                Console.WriteLine("Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {newRecord:f3}.");
            }
            else
            {
                Console.WriteLine($"No, Marin failed! He was {newRecord - oldRecord:f3} second slower.");
            }



        }
    }
}
