using System;

namespace SchoolCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Сезонът – текст - “Winter”, “Spring” или “Summer”;
            //2.Видът на групата – текст - “boys”, “girls” или “mixed”;
            //3.Брой на учениците – цяло число в интервала[1 … 10000];
            //4.Брой на нощувките – цяло число в интервала[1 … 100].
            string season = Console.ReadLine();
            string groupType = Console.ReadLine();
            int students = int.Parse(Console.ReadLine());
            int night = int.Parse(Console.ReadLine());

            string sports = "";

            double price = 0;

            switch (groupType)
            {
                case "girls":
                    switch (season)
                    {
                        case "Winter":
                            price = students * night * 9.6;
                            sports = "Gymnastics";
                            break;
                        case "Spring":
                            price = students * night * 7.2;
                            sports = "Athletics";
                            break;
                        case "Summer":
                            price = students * night * 15.0;
                            sports = "Volleyball";
                            break;
                    }
                    break;

                case "boys":
                    switch (season)
                    {
                        case "Winter":
                            price = students * night * 9.6;
                            sports = "Judo";
                            break;
                        case "Spring":
                            price = students * night * 7.2;
                            sports = "Tennis";
                            break;
                        case "Summer":
                            price = students * night * 15.0;
                            sports = "Football";
                            break;
                    }
                    break;

                case "mixed":
                    switch (season)
                    {
                        case "Winter":
                            price = students * night * 10.0;
                            sports = "Ski";
                            break;
                        case "Spring":
                            price = students * night * 9.5;
                            sports = "Cycling";
                            break;
                        case "Summer":
                            price = students * night * 20.0;
                            sports = "Swimming";
                            break;
                    }
                    break;
            }

            if (students >= 50)
            {
                price *= 0.5;
            }
            else if (students >= 20)
            {
                price *= 0.85;
            }
            else if (students >= 10)
            {
                price *= 0.95;
            }

            Console.WriteLine($"{sports} {price:f2} lv.");

        }
    }
}
