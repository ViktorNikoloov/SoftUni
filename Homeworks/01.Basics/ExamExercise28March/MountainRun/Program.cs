using System;

namespace MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //1.Рекордът в секунди – реално число в интервала [0.00 … 100000.00]
            //2.Разстоянието в метри – реално число в интервала[0.00 … 100000.00]
            //3.Времето в секунди, за което изкачва 1 м. – реално число в интервала[0.00 … 1000.00]
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeClibing = double.Parse(Console.ReadLine());

            //calculation
            //наклона на терена го забавя на всеки 50 м.с 30 секунди.
            double delay = Math.Floor(distance / 50) * 30;

            //Да се изчисли времето в секунди, за което Георги ще изкачи разстоянието до върха и разликата спрямо рекорда. 
            double newRecord = (distance * timeClibing) + delay;

            //output
            if (newRecord < record)
            {
                Console.WriteLine($"Yes! The new record is {newRecord:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {newRecord - record:f2} seconds slower.");
            }

        }
    }
}
