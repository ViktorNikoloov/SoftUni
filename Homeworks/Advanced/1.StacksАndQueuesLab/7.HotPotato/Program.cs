using System;
using System.Collections.Generic;
using System.Net;

namespace _7.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            Queue<string> names = new Queue<string>(input);

            while (names.Count > 1)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (i == n)
                    {
                        Console.WriteLine($"Removed {names.Dequeue()}");
                    }
                    string currName = names.Dequeue();
                    names.Enqueue(currName);

                    
                }
            }

            Console.WriteLine($"Last is {names.Dequeue()}");
        }
    }
}
