using System;

namespace SummerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int degree = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();

            string outfit = "";
            string shoes = "";

            if (10 <= degree && degree <= 18)
            {
                if (time == "Morning")
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";

                }
                else if (time == "Afternoon")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";

                }
                else
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";

                }
            }
            else if (18 < degree && degree <= 24)
            {
                if (time == "Morning")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";

                }
                else if (time == "Afternoon")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";


                }
                else
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";

                }
            }
            else if (degree >= 25)
            {
                if (time == "Morning")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";

                }
                else if (time == "Afternoon")
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";



                }
                else
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";

                }
            }
            Console.WriteLine($"It's {degree} degrees, get your {outfit} and {shoes}.");
        }
    }
}
