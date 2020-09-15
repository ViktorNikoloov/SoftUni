using System;

namespace FuelTank
{
    class Program
    {
        static void Main(string[] args)
        {
            // input
            string fuel = Console.ReadLine();
            double litres = double.Parse(Console.ReadLine());


            //възможности: "Diesel", "Gasoline" или "Gas", 
            //Ако литрите гориво са повече или равни на 25, на конзолата да се отпечата "You have enough {вида на горивото}.
            if (fuel == "Diesel" || fuel == "Gasoline" || fuel == "Gas")
            {
                if (litres >= 25)
                {
                    if (fuel == "Diesel")
                    {
                        Console.WriteLine($"You have enough {fuel.ToLower()}.");
                    }
                    if (fuel == "Gasoline")
                    {
                        Console.WriteLine($"You have enough {fuel.ToLower()}.");
                    }
                    if (fuel == "Gas")
                    {
                        Console.WriteLine($"You have enough {fuel.ToLower()}.");
                    }


                }
                else if (litres < 25)
                {
                    if (fuel == "Diesel")
                    {
                        Console.WriteLine($"Fill your tank with {fuel.ToLower()}!");
                    }
                    if (fuel == "Gasoline")
                    {
                        Console.WriteLine($"Fill your tank with {fuel.ToLower()}!");
                    }
                    if (fuel == "Gas")
                    {
                        Console.WriteLine($"Fill your tank with {fuel.ToLower()}!");
                    }
                }
            }
            else 
            {
                Console.WriteLine("Invalid fuel!");
            }
            
            //}.", ако са по-малко от 25, да се отпечата "Fill your tank with {вида на горивото}!". 
            
        
            //различно от посоченото, да се отпечата "Invalid fuel!".
        }
    }
}
