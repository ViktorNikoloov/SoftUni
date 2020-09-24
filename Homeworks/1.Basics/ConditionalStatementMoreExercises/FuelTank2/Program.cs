using System;

namespace FuelTank2
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Типа на горивото – текст с възможности: "Gas", "Gasoline" или "Diesel"
            //•	Количество гориво – реално число в интервала[1.00 … 50.00]
            //•	Притежание на клубна карта – текст с възможности: "Yes" или "No"
            string fuelKind = Console.ReadLine();
            double litres = double.Parse(Console.ReadLine());
            string card = Console.ReadLine();
            
            // Gasoline - 2.22/l
            //Diesel – 2.33/l
            //Gas – 0.93/l
            double gasoline = 2.22;
            double diesel = 2.33;
            double gas = 0.93;

            // Calculation
            // Discount with Card: Gasoline - 0.18/l, Diesel - 0.12/l, Gas 0.08/l
            if ((fuelKind == "Gas" || fuelKind == "Gasoline" || fuelKind == "Diesel") & card == "Yes")
            {
                //Discount litres > 25 - 10% of totalSum
                if (litres > 25)
                {
                    if (fuelKind == "Gasoline")
                    {
                        Console.WriteLine($"{((gasoline - 0.18) * litres) * 0.90:f2} lv.");
                    }
                    else if (fuelKind == "Diesel")
                    {
                        Console.WriteLine($"{((diesel - 0.12) * litres) * 0.90:f2} lv.");
                    }
                    else if (fuelKind == "Gas")
                    {
                        Console.WriteLine($"{((gas - 0.08) * litres) * 0.90:f2} lv.");
                    }
                }
                //between  20 and 25(litres) - 8% of totalSum
                else if (litres >= 20 && litres <= 25)
                {
                    if (fuelKind == "Gasoline")
                    {
                        Console.WriteLine($"{((gasoline - 0.18) * litres) * 0.92:f2} lv.");
                    }
                    else if (fuelKind == "Diesel")
                    {
                        Console.WriteLine($"{((diesel - 0.12) * litres) * 0.92:f2} lv.");
                    }
                    else if (fuelKind == "Gas")
                    {
                        Console.WriteLine($"{((gas - 0.08) * litres) * 0.92:f2} lv.");
                    }
                }
                else if (litres >= 0 && litres < 20)
                {
                    if (fuelKind == "Gasoline")
                    {
                        Console.WriteLine($"{((gasoline - 0.18) * litres):f2} lv.");
                    }
                    else if (fuelKind == "Diesel")
                    {
                        Console.WriteLine($"{((diesel - 0.12) * litres):f2} lv.");
                    }
                    else if (fuelKind == "Gas")
                    {
                        Console.WriteLine($"{((gas - 0.08) * litres):f2} lv.");
                    }
                }
            }
            if ((fuelKind == "Gas" || fuelKind == "Gasoline" || fuelKind == "Diesel") & card == "No")
            {
                if (litres > 25)
                {
                    if (fuelKind == "Gasoline")
                    {
                        Console.WriteLine($"{(gasoline * litres) * 0.9:f2} lv.");
                    }
                    else if (fuelKind == "Diesel")
                    {
                        Console.WriteLine($"{(diesel * litres) * 0.9:f2} lv.");
                    }
                    else if (fuelKind == "Gas")
                    {
                        Console.WriteLine($"{(gas * litres) * 0.9:f2} lv.");
                    }
                }
                else if (litres >= 20 && litres <= 25)
                {
                    if (fuelKind == "Gasoline")
                    {
                        Console.WriteLine($"{(gasoline * litres) * 0.92:f2} lv.");
                    }
                    else if (fuelKind == "Diesel")
                    {
                        Console.WriteLine($"{(diesel * litres) * 0.92:f2} lv.");
                    }
                    else if (fuelKind == "Gas")
                    {
                        Console.WriteLine($"{(gas * litres) * 0.92:f2} lv.");
                    }
                    
                }
                else if (litres >= 0 && litres < 20)
                {
                    if (fuelKind == "Gasoline")
                    {
                        Console.WriteLine($"{gasoline * litres:f2} lv.");
                    }
                    else if (fuelKind == "Diesel")
                    {
                        Console.WriteLine($"{diesel * litres:f2} lv.");
                    }
                    else if (fuelKind == "Gas")
                    {
                        Console.WriteLine($"{gas * litres:f2} lv.");
                    }
                }
            }
        }
    }
}
