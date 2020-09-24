using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> circle = new Queue<string>();

            int numberOfPopmps = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPopmps; i++)
            {
                string input = Console.ReadLine();
                input += $" {i}";
                circle.Enqueue(input);
            }

            int petrol = 0;
           
            for (int i = 0; i < numberOfPopmps; i++)
            {
                string petrolInfo = circle.Dequeue();
                int[] infoSplited = petrolInfo.Split().Select(int.Parse).ToArray();

                petrol += infoSplited[0];
                int distance = infoSplited[1];

                if (!(petrol >= distance))
                {
                    circle.Enqueue(petrolInfo);
                    petrol = 0;
                    i = -1;
                }
                else
                {
                    circle.Enqueue(petrolInfo);
                    petrol -= distance;
                }

            }
            int[] indexe = circle.Dequeue().Split().Select(int.Parse).ToArray();

            Console.WriteLine(indexe[2]);
        }
    }
}
