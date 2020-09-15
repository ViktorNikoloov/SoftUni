using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split("@", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int lastIndex = 0;
            int houseCount = 0;
            bool isFail = false;
            List<string> command = Console.ReadLine().Split().ToList();

            while (command[0] != "Love!")
            {
                int newIndex = lastIndex + int.Parse(command[1]);
                
                if (0 > newIndex || newIndex >= list.Count) // 1 2 3 4 5 6
                {
                    newIndex = 0;
                }

                if (list[newIndex] == 0)
                {
                    Console.WriteLine($"Place {newIndex} already had Valentine's day.");
                }
                else
                {
                    list[newIndex] -= 2;
                    
                    if (list[newIndex] == 0)
                    {
                        Console.WriteLine($"Place {newIndex} has Valentine's day.");
                    }
                }

                lastIndex = newIndex;
                command = Console.ReadLine().Split().ToList();
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != 0)
                {
                    houseCount++;
                    isFail = true;
                }
            }

            Console.WriteLine($"Cupid's last position was {lastIndex}.");
            
            if (isFail)
            {
                Console.WriteLine($"Cupid has failed {houseCount} places.");
            }
            else
            {
                Console.WriteLine($"Mission was successful.");
            }
        }
    }
}
