using System;

namespace _6._Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());
            int floorCounter = 0;
            int roomsCounter = 0;

            for (int f = floors; f >= 1; f--)
            {
                floorCounter++;
                for (int r = 0; r < rooms; r++)
                {
                    roomsCounter++;
                    if (floorCounter == 1)
                    {
                        Console.Write($"L{f}{r} ");
                    }
                    if (f % 2 == 0 && floorCounter != 1)
                    {
                        
                        Console.Write($"О{f}{r} ");
                    }
                    if (f % 2 == 1 && floorCounter != 1)
                    {
                        
                        Console.Write($"А{f}{r} ");
                    }
                    
                }
            }
        }
    }
}
