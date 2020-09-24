using System;

namespace SkiiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            //Conditional
            //"room for one person" – 18.00 лв за нощувка
            //"apartment" – 25.00 лв за нощувка
            //"president apartment" – 35.00 лв за нощувка
            // if posotiv +25% of totalSum
            //if negativ - 10% of totalSum
            


            //input
            // Първи ред -дни за престой -цяло число в интервала[0...365]
            // Втори ред -вид помещение - "room  for  one  person", "apartment" или "president  apartment"
            // Трети ред -оценка - "positive"  или "negative"
            int days = int.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string rating = Console.ReadLine();

            double room = 18.00;
            double apartment = 25.00;
            double president = 35.00;
            double price = 0;

            //Calculation
            if (days > 0)
            {
                days -= 1;
            }

            if (rating == "positive")
            {
                if (days > 0 && days < 10)
                {
                    if (typeOfRoom == "room for one person")
                    {
                        price = room * days;
                    }
                    else if (typeOfRoom == "apartment")
                    {
                        price = (apartment * days) * 0.7;
                    }
                    else
                    {
                        price = (president * days) * 0.9;
                    }
                }
                else if (days >= 10 && days <= 15)
                {

                    if (typeOfRoom == "room for one person")
                    {
                        price = room * days;
                    }
                    else if (typeOfRoom == "apartment")
                    {
                        price = (apartment * days) * 0.65;
                    }
                    else
                    {
                        price = (president * days) * 0.85;
                    }
                }
                else if (days > 15)
                {

                    if (typeOfRoom == "room for one person")
                    {
                        price = room * days;
                    }
                    else if (typeOfRoom == "apartment")
                    {
                        price = (apartment * days) * 0.5;
                    }
                    else
                    {
                        price = (president * days) * 0.8;
                    }
                }

                Console.WriteLine($"{price + (price * 0.25):f2}");
            }

            else if (rating == "negative")
            {
                if (days > 0 && days < 10)
                {
                    if (typeOfRoom == "room for one person")
                    {
                        price = room * days;
                    }
                    else if (typeOfRoom == "apartment")
                    {
                        price = (apartment * days) * 0.7;
                    }
                    else
                    {
                        price = (president * days) * 0.9;
                    }
                }
                else if (days >= 10 && days <= 15)
                {
                    if (typeOfRoom == "room for one person")
                    {
                        price = room * days;
                    }
                    else if (typeOfRoom == "apartment")
                    {
                        price = (apartment * days) * 0.65;
                    }
                    else
                    {
                        price = (president * days) * 0.85;
                    }
                }
                else if (days > 15)
                {
                    if (typeOfRoom == "room for one person")
                    {
                        price = room * days;
                    }
                    else if (typeOfRoom == "apartment")
                    {
                        price = (apartment * days) * 0.5;
                    }
                    else
                    {
                        price = (president * days) * 0.8;
                    }
                }

                Console.WriteLine($"{price * 0.9:f2}");
            }               
        }
    }
}
