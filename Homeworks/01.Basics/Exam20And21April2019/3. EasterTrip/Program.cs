using System;

namespace _3._EasterTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //Първи ред - дестинация "France", "Italy" или "Germany"
            //Втори ред - дати "21-23","24-27" или "28-31"
            //Трети ред - брой нощувки - цяло число в интервала [1… 100]
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            int price = 0;

            //calculation
            switch (destination)
            {
                case "France":
                    switch (dates)
                    {
                        case "21-23":
                            price = 30;
                            break;

                        case "24-27":
                            price = 35;
                            break;

                        case "28-31":
                            price = 40;
                            break;
                    }
                    break;

                case "Italy":
                    switch (dates)
                    {
                        case "21-23":
                            price = 28;
                            break;

                        case "24-27":
                            price = 32;
                            break;

                        case "28-31":
                            price = 39;
                            break;
                    }
                    break;

                case "Germany":
                    switch (dates)
                    {
                        case "21-23":
                            price = 32;
                            break;

                        case "24-27":
                            price = 37;
                            break;

                        case "28-31":
                            price = 43;
                            break;
                    }
                    break;
            }

            int holidayPrice = nights * price;
            Console.WriteLine($"Easter trip to {destination} : {holidayPrice:f2} leva.");

        }
    }
}
