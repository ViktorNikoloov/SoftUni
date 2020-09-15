using System;

namespace MatchTicketsMore
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string status = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());
            double costs = 0;
            double normalTicket = 249.99 * people;
            double vipTicket = 499.99 * people;

            // ticket price =	VIP – 499.99 лева. / Normal – 249.99 лева.
            //•	От 1 до 4 – 75 % от бюджета.
            //•	От 5 до 9 – 60 % от бюджета.
            //•	От 10 до 24 – 50 % от бюджета.
            //•	От 25 до 49 – 40 % от бюджета.
            //•	50 или повече – 25 % от бюджета.

            if (0 < people && people <= 4)
            {
               costs = budget * 0.75;
            }
            else if (people <= 9)
            {
                costs = budget * 0.60;
            }
            else if (people <= 24)
            {
                costs = budget * 0.50;
            }
            else if (people <= 49)
            {
                costs = budget * 0.40;
            }
            else if (people >= 50)
            {
                costs = budget * 0.25;
            }

            double budetLeft = budget - costs;
            //// ticket price =	VIP – 499.99 лева. / Normal – 249.99 лева.
            if (status == "VIP")
            {
                if (budetLeft >= vipTicket)
                {
                    Console.WriteLine($"Yes! You have {budetLeft - vipTicket:f2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money! You need {vipTicket - budetLeft:f2} leva.");
                }
            }

            else
            {
                if (budetLeft >= normalTicket)
                {
                    Console.WriteLine($"Yes! You have {budetLeft - normalTicket:f2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money! You need {normalTicket - budetLeft:f2} leva.");
                }
            }

        }
    }
}
