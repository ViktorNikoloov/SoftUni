using System;

namespace Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            //необходимите часовете – цяло число в интервала [0 ... 200 000]
            //дните, с които фирмата разполага – цяло число в интервала [0 ... 20 000]
            //броят на служителите, работещи извънредно – цяло число в интервала [0 ... 200]
            int hoursNeeded = int.Parse(Console.ReadLine());
            int daysLimit = int.Parse(Console.ReadLine());
            int employee = int.Parse(Console.ReadLine());
            // Calculation
            //През 10% от дните служителите са на обучение и не могат да работят.
            double daysLeft = daysLimit * 0.9;
            //Един нормален работен ден във фирмата е 8 часа.
            double firmHours = daysLeft * 8;
            //Всеки служител може да работи по проекта в извънработно време по 2 часа на ден.
            double extraHours = (employee * 2) * daysLimit;
            double totalHours = firmHours + extraHours;
            //Ако времето е достатъчно:
            if (totalHours >= hoursNeeded)
            {
                Console.WriteLine($"Yes!{Math.Floor(totalHours - hoursNeeded)} hours left.");
            }
            //Ако  времето НЕ Е достатъчно:
            else
            {
                Console.WriteLine($"Not enough time!{Math.Ceiling(hoursNeeded - totalHours)} hours needed.");
            }
        }
    }
}
