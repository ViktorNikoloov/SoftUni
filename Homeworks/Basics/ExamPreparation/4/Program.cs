using System;
using System.Threading;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Първоначален брой точки  –  цяло положително число в интервала[1 … 1000];
            //След това последователно се четат по два реда:
            //Сектор на мишената – текст с възможности: "number section", "double ring", "triple ring", "bullseye"
            //Брой точки  – цяло положително число в интервала[1 … 100]
            int startPoints = int.Parse(Console.ReadLine());
            int counter = 0;
   
            while (startPoints >= 0)
            {
                
                if (startPoints == 0)
                {
                    Console.WriteLine($"Congratulations! You won the game in {counter} moves!");
                    break;
                }
                string targetSector = Console.ReadLine();
                counter++;

                if (targetSector == "bullseye")
                {
                    Console.WriteLine($"Congratulations! You won the game with a bullseye in {counter} moves!");
                    break;
                }
                int points = int.Parse(Console.ReadLine());
                
                switch (targetSector)
                {
                    case "number section":
                        startPoints -= points;
                        break;

                    case "double ring":
                        startPoints -= points * 2;
                        break;

                    case "triple ring":
                        startPoints -= points * 3;
                        break;
                }
               
            }

            if (startPoints < 0)
            {
            Console.WriteLine($"Sorry, you lost. Score difference: {Math.Abs(startPoints)}.");
            }
        }
    }
}
