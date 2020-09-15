using System;

namespace SleepyTomCat
{
    class Program
    {
        static void Main(string[] args)
        {
            // condition
            // Напишете програма, която въвежда броя почивни дни и отпечатва дали Том може да се наспи добре и 
            //колко е разликата от нормата за текущата година, като приемем че годината има 365 дни.

            // input
            //броят почивни дни – цяло число в интервала [0...365]
            int dayOff = int.Parse(Console.ReadLine());

            // calculation
            // За да се наспи добре, ормата за игра на Том е 30 000  минути в година.
            // Когато е на работа, стопанинът му си играе с него по 63 минути на ден.
            // Когато почива, стопанинът му си играе с него по 127 минути на ден.

            int remainDays = 365 - dayOff;
            int workPlay = remainDays * 63;
            int dayOffPlay = dayOff * 127;
            double totalPlay = workPlay + dayOffPlay;
            int norm = 30000;
            double normRemain = 30000 - totalPlay;
            double hours = Math.Abs(normRemain) / 60;
            double minutes = (hours - Math.Floor(hours)) * 60;

            //output
            if (norm < totalPlay)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{Math.Floor(hours)} hours and {minutes:f0} minutes more for play");
            }

            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{Math.Floor(hours)} hours and {minutes:f0} minutes less for play");
            }
        }
    }
}
