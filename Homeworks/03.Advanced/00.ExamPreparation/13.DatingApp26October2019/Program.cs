using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.DatingApp26October2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] malesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] femalesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int matches = 0;

            Queue<int> females = new Queue<int>(femalesInput);
            Stack<int> males = new Stack<int>(malesInput);

            while (females.Count > 0 && males.Count > 0)
            {
                int currFemale = females.Peek();
                int currMales = males.Peek();

                if (currFemale <= 0)
                {
                    females.Dequeue();
                    continue;
                }
                if (currMales <= 0)
                {
                    males.Pop();
                    continue;
                }

                if ((currFemale % 25) == 0)
                {
                    females.Dequeue();
                    if (females.Count != 0)
                    {
                        females.Dequeue();
                    }

                    continue;
                }
                if ((currMales % 25) == 0)
                {
                    males.Pop();
                    if (males.Count != 0)
                    {
                        males.Pop();
                    }
                    continue;

                }

                if (currFemale == currMales)
                {
                    matches++;
                    females.Dequeue();
                    males.Pop();
                }
                else
                {
                    females.Dequeue();
                    males.Push(males.Pop() - 2);
                }

            }

            Console.WriteLine($"Matches: {matches}");
            if (males.Count != 0)
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }

            if (females.Count != 0)
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }

        }
    }
}