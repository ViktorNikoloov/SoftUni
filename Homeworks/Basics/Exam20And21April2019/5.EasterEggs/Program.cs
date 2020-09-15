using System;

namespace _5.EasterEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Броят на боядисаните яйца – цяло число в интервала[1... 100]
            //За всяко яйце се чете:
            //Цветът на яйцето – текст с възможности: "red", "orange", "blue", "green"
            int paintedEggs = int.Parse(Console.ReadLine());
            int redEgg = 0;
            int orangeEgg = 0;
            int blueEgg = 0;
            int greenEgg = 0;
            int biggerNumber = int.MinValue;
            string colourOfTheBigger = "";
            

            for (int i = 0; i < paintedEggs; i++)
            {
                string eggColour = Console.ReadLine();

                if (eggColour == "red")
                {
                    redEgg++;
                }
                else if (eggColour == "orange")
                {
                    orangeEgg++;
                }
                else if (eggColour == "blue")
                {
                    blueEgg++;
                }
                else if (eggColour == "green")
                {
                    greenEgg++;
                }

            }

            if (biggerNumber < redEgg )
            {
                biggerNumber = redEgg;
                colourOfTheBigger = "red";
            }
            if (biggerNumber < orangeEgg)
            {
                biggerNumber = orangeEgg;
                colourOfTheBigger = "orange";
            }
            if (biggerNumber < blueEgg)
            {
                biggerNumber = blueEgg;
                colourOfTheBigger = "blue";
            }
            if (biggerNumber < greenEgg)
            {
                biggerNumber = greenEgg;
                colourOfTheBigger = "green";
            }

            Console.WriteLine($"Red eggs: {redEgg}");
            Console.WriteLine($"Orange eggs: {orangeEgg}");
            Console.WriteLine($"Blue eggs: {blueEgg}");
            Console.WriteLine($"Green eggs: {greenEgg}");
            Console.WriteLine($"Max eggs: {biggerNumber} -> {colourOfTheBigger}");

        }
    }
}
