using System;

namespace _7._VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double insertSum = 0;

            while (input != "Start")
            {
                //0.1, 0.2, 0.5, 1, and 2 
                double coins = double.Parse(input);
                if (coins == 0.1 && coins == 0.2 && coins == 0.5 && coins == 1 && coins == 2)
                {
                    insertSum += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
                input = Console.ReadLine();
            }
            string products = Console.ReadLine();
            while (products != "End")
            {
                //"Nuts", "Water", "Crisps", "Soda", "Coke". 
                // 2.0,     0.7,     1.5,     0.8,     1.0 
                switch (products)
                {
                    case "Nuts":
                        insertSum -= 2.0;
                        if (insertSum >= 0)
                        {
                            Console.WriteLine("Purchased" + " nuts");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            insertSum += 2.0;
                        }
                        break;

                    case "Water":
                        insertSum -= 0.7;
                        if (insertSum >= 0)
                        {
                            Console.WriteLine("Purchased" + " water");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            insertSum += 0.7;
                        }
                        break;

                    case "Crisps":
                        insertSum -= 1.5;
                        if (insertSum >= 0)
                        {
                            Console.WriteLine("Purchased" + " crisps");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            insertSum += 1.5;
                        }
                        break;

                    case "Soda":
                        insertSum -= 0.8;
                        if (insertSum >= 0)
                        {
                            Console.WriteLine("Purchased" + " soda");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            insertSum += 0.8;
                        }
                        break;

                    case "Coke":
                        insertSum -= 1.0;
                        if (insertSum >= 0)
                        {
                            Console.WriteLine("Purchased" + " coke");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            insertSum += 1.0;
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid product");
                        break;

                }
                products = Console.ReadLine();

            }
            Console.WriteLine($"Change: {insertSum:f2}");
        }
    }
}
