using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int widghtFreeSpace = int.Parse(Console.ReadLine());
            int lenghFreeSpace = int.Parse(Console.ReadLine());
            int hightFreeSpace = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int freeSpace = widghtFreeSpace * lenghFreeSpace * hightFreeSpace;

            int boxSum = 0;

            while (input != "Done")
            {
                int boxNumber = int.Parse(input);

                boxSum += boxNumber;

                if (freeSpace < boxSum)
                {

                    Console.WriteLine($"No more free space! You need {boxSum - freeSpace} Cubic meters more.");
                    break;
                }

                input = Console.ReadLine();
            }

            if (freeSpace > boxSum)
            {
                Console.WriteLine($"{freeSpace - boxSum} Cubic meters left.");

            }
        }
    }
}