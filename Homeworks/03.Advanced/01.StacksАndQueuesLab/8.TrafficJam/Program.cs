using System;
using System.Collections.Generic;

namespace _8.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int counter = 0;
            int n = int.Parse(Console.ReadLine());

            string commands = Console.ReadLine();
            while (commands != "end")
            {
                if (commands == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count <= 0)
                        {
                            break;
                        }
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        counter++;
                    }
                }
                else
                {
                    cars.Enqueue(commands);
                }

                commands = Console.ReadLine();
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
