using System;

namespace _3.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPeople = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfTheWeek = Console.ReadLine();
            double price = 0;

            switch (groupType)
            {
                case "Students":
                    switch (dayOfTheWeek)
                    {
                        case "Friday":
                            price = numOfPeople * 8.45;
                            break;

                        case "Saturday":
                            price = numOfPeople * 9.80;
                            break;

                        case "Sunday":
                            price = numOfPeople * 10.46;
                            break;
                    }
                    break;

                case "Business":
                    switch (dayOfTheWeek)
                    {
                        case "Friday":
                            price = numOfPeople * 10.90;
                            break;

                        case "Saturday":
                            price = numOfPeople * 15.60;
                            break;

                        case "Sunday":
                            price = numOfPeople * 16.00;
                            break;
                    }
                    break;

                case "Regular":
                    switch (dayOfTheWeek)
                    {
                        case "Friday":
                            price = numOfPeople * 15.00;
                            break;

                        case "Saturday":
                            price = numOfPeople * 20.00;
                            break;

                        case "Sunday":
                            price = numOfPeople * 22.50;
                            break;
                    }
                    break;

            }
            if (groupType == "Students" && numOfPeople >= 30)
            {
                price *= 0.85;
            }
            if (groupType == "Business" && numOfPeople >= 100)
            {
                price -= (price / numOfPeople) * 10;
            }
            if (groupType == "Regular" && 10 <= numOfPeople && numOfPeople <= 20)
            {
                price *= 0.95;
            }

            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
