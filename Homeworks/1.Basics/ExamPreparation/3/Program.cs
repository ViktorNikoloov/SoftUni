using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Първият ред – вид круиз – текст с възможности: "Mediterranean", "Adriatic", "Aegean"
            //•	Вторият ред – вид каюта – текст с възможности: "standard cabin", "cabin with balcony", "apartment"
            //•	Третият ред – брой нощувки – цяло число в интервала[1… 50]
            string cruisType = Console.ReadLine();
            string roomType = Console.ReadLine();
            int numberOfNights = int.Parse(Console.ReadLine());
            double price = 0;

            switch (cruisType)
            {
                case "Mediterranean":
                    switch (roomType)
                    {
                        case "standard cabin":
                            price = 27.50;
                            break;

                        case "cabin with balcony":
                            price = 30.20;
                            break;

                        case "apartment":
                            price = 40.50;
                            break;
                    }
                    break;

                case "Adriatic":
                    switch (roomType)
                    {
                        case "standard cabin":
                            price = 22.99;
                            break;

                        case "cabin with balcony":
                            price = 25.00;
                            break;

                        case "apartment":
                            price = 34.99;
                            break;
                    }
                    break;                 

                case "Aegean":
                    switch (roomType)
                    {
                        case "standard cabin":
                            price = 23.00;
                            break;

                        case "cabin with balcony":
                            price = 26.60;
                            break;

                        case "apartment":
                            price = 39.80;
                            break;
                    }
                    break;

            }

            double totalPrice = 4 * price * numberOfNights;
            if (numberOfNights > 7)
            {
                totalPrice *= 0.75;
            }
            

            Console.WriteLine($"Annie's holiday in the {cruisType} sea costs {totalPrice:f2} lv.");
        }
    }
}
