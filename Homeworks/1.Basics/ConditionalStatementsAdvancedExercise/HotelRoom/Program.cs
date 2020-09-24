using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string mounth = Console.ReadLine();
            double night = double.Parse(Console.ReadLine());
            double studioPrice = 0;
            double apartmentPrice = 0;

            //May, June, July, August, 
            //September или October

            switch (mounth)
            {
                case "May":
                case "October":
                    studioPrice = 50 * night;
                    apartmentPrice = 65 * night;
                    break;

                case "June":
                case "September":
                    studioPrice = 75.2 * night;
                    apartmentPrice = 68.7 * night;
                    break;

                case "July":
                case "August":
                    studioPrice = 76 * night;
                    apartmentPrice = 77 * night;
                    break;
            }

            if ((mounth == "May" || mounth == "October") && night > 7 && night <= 14)
            {
                studioPrice *= 0.95;
            }

            else if ((mounth == "May" || mounth == "October") && night > 14)
            {
                studioPrice *= 0.7;
                apartmentPrice *= 0.9;
            }

            else if ((mounth == "June" || mounth == "September") && night > 14)
            {
                studioPrice *= 0.8;
                apartmentPrice *= 0.9;
            }

            else if ((mounth == "July" || mounth == "August") && night > 14)
            {
                apartmentPrice *= 0.9;
            }

            Console.WriteLine($"Apartment: {apartmentPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
        }
    }
}
