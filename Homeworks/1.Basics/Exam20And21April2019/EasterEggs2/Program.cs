using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	 Броят на боядисаните яйца – цяло число в интервала [1 ... 100]
            //За всяко яйце се чете:
            //o Цветът на яйцето – текст с възможности: "red", "orange", "blue", "green"

            int eggssNumber = int.Parse(Console.ReadLine());
            int redCounter = 0;
            int orangeCounter = 0;
            int blueCounter = 0;
            int greenCounter = 0;
            int maxCounter = int.MinValue;
            string maxColour = "";

            for (int i = 0; i < eggssNumber; i++)
            {
                string colour = Console.ReadLine();

                switch (colour)
                {
                    case "red":
                        redCounter++;
                        break;

                    case "orange":
                        orangeCounter++;
                        break;

                    case "blue":
                        blueCounter++;
                        break;

                    case "green":
                        greenCounter++;
                        break;
                }
            }

            if (redCounter > maxCounter)
            {
                maxCounter = redCounter;
                maxColour = "red";
            }
            if (orangeCounter > maxCounter)
            {
                maxCounter = orangeCounter;
                maxColour = "orange";
            }
            if (blueCounter > maxCounter)
            {
                maxCounter = blueCounter;
                maxColour = "blue";
            }
            if (greenCounter > maxCounter)
            {
                maxCounter = greenCounter;
                maxColour = "green";
            }

            Console.WriteLine($"Red eggs: {redCounter}");
            Console.WriteLine($"Orange eggs: {orangeCounter}");
            Console.WriteLine($"Blue eggs: {blueCounter}");
            Console.WriteLine($"Green eggs: {greenCounter}");
            Console.WriteLine($"Max eggs: {maxCounter} -> {maxColour}");
        }
    }
}
