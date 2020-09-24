using System;

namespace _3._PaintingEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            string size = Console.ReadLine();
            string colour = Console.ReadLine();
            int numbers = int.Parse(Console.ReadLine());
            double price = 0;

            //calculafion
            switch (size)
            {
                case "Large":
                    switch (colour)
                    {
                        case "Red":
                            price = 16;
                            break;

                        case "Green":
                            price = 12;
                            break;

                        case "Yellow":
                            price = 9;
                            break;
                    }
                    break;

                case "Medium":
                    switch (colour)
                    {
                        case "Red":
                            price = 13;
                            break;

                        case "Green":
                            price = 9;
                            break;

                        case "Yellow":
                            price = 7;
                            break;
                    }
                    break;

                case "Small":
                    switch (colour)
                    {
                        case "Red":
                            price = 9;
                            break;


                        case "Green":
                            price = 8;
                            break;

                        case "Yellow":
                            price = 5;
                            break;
                    }
                    break;

            }

            double sumWithoutCosts = (price * numbers) * 0.65;
            Console.WriteLine($"{sumWithoutCosts:f2} leva.");

        }
    }
}
