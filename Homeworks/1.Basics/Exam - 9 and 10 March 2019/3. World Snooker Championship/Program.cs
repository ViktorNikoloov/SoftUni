using System;

namespace _3._World_Snooker_Championship
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //1.	Етап на първенството – текст - “Quarter final ”, “Semi final” или “Final”
            //2.Вид на билета – текст - “Standard”, “Premium” или “VIP”
            //3.Брой билети – цяло число в интервала[1 … 30]
            //4.Снимка с трофея – символ – 'Y'(да) или 'N'(не)
            string stage = Console.ReadLine();
            string ticketType = Console.ReadLine();
            int numberOfTickets = int.Parse(Console.ReadLine());
            string photo = Console.ReadLine();
            double totalPrice = 0;

            //calculation           
            switch (stage)
            {
                case "Quarter final":
                    switch (ticketType)
                    {
                        case "Standard":
                            totalPrice += numberOfTickets * 55.50;
                            break;
                        case "Premium":
                            totalPrice += numberOfTickets * 105.20;
                            break;
                        case "VIP":
                            totalPrice += numberOfTickets * 118.90;
                            break;
                    }
                    break;
                case "Semi final":
                    switch (ticketType)
                    {
                        case "Standard":
                            totalPrice += numberOfTickets * 75.88;
                            break;
                        case "Premium":
                            totalPrice += numberOfTickets * 125.22;
                            break;
                        case "VIP":
                            totalPrice += numberOfTickets * 300.40;
                            break;
                    }
                    break;
                case "Final":
                    switch (ticketType)
                    {
                        case "Standard":
                            totalPrice += numberOfTickets * 110.10;
                            break;
                        case "Premium":
                            totalPrice += numberOfTickets * 160.66;
                            break;
                        case "VIP":
                            totalPrice += numberOfTickets * 400.00;
                            break;
                    }
                    break;

            }
            //снимка с трофея, на цена 40 лири.
            //•	Над 4000 лири има 25% отстъпка и безплатни снимки с трофея (ако  опцията за снимки е избрана, таксата от 40 лири за билет не се включва)
            //Над 2500 лири има 10 % отстъпка
            
            if (totalPrice > 4000)
            {
                totalPrice *= 0.75;
                if (photo == "Y")
                {
                    totalPrice -= numberOfTickets * 40;
                }
                
            }
            else if (2500 < totalPrice && totalPrice <= 4000)
            {
                totalPrice *= 0.9;
            }


            if (photo == "Y")
            {
                totalPrice += numberOfTickets* 40;
            }

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
