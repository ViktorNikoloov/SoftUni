using System;

namespace _13.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            double userBalance = balance;

            string games = Console.ReadLine();

            while (games != "Game Time") //&& userBalance != 0)
            {
                if (userBalance <= 0)
                {
                    break;
                }
                switch (games)
                {
                    case "OutFall 4":
                    case "RoverWatch Origins Edition":
                        if (userBalance < 39.99)
                        {
                            Console.WriteLine("Too Expensive");
                            break;
                        }
                        userBalance -= 39.99;
                        Console.WriteLine($"Bought {games}");
                        break;

                    case "CS: OG":
                        if (userBalance < 15.99)
                        {
                            Console.WriteLine("Too Expensive");
                            break;
                        }
                        userBalance -= 15.99;
                        Console.WriteLine($"Bought {games}");
                        break;

                    case "Zplinter Zell":
                        if (userBalance < 19.99)
                        {
                            Console.WriteLine("Too Expensive");
                            break;
                        }
                        userBalance -= 19.99;
                        Console.WriteLine($"Bought {games}");
                        break;

                    case "Honored 2":
                        if (userBalance < 59.99)
                        {
                            Console.WriteLine("Too Expensive");
                            break;
                        }
                        userBalance -= 59.99;
                        Console.WriteLine($"Bought {games}");
                        break;

                    case "RoverWatch":
                        if (userBalance < 29.99)
                        {
                            Console.WriteLine("Too Expensive");
                            break;
                        }
                        userBalance -= 29.99;
                        Console.WriteLine($"Bought {games}");
                        break;

                    default:
                        Console.WriteLine("Not Found");
                        break;
                }
                games = Console.ReadLine();
            }
            if (userBalance <=0)
            {
                Console.WriteLine("Out of money! ");
            }
            else
            {
                Console.WriteLine($"Total spent: ${balance - userBalance:f2}. Remaining: ${userBalance:f2}");
            }
        }
    }
}
