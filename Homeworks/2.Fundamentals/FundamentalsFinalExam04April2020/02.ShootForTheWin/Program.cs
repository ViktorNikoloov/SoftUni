using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            int shooted = 0;

            string index = Console.ReadLine();
            while (index != "End")
            {
                if (0 <= int.Parse(index) && int.Parse(index) < targets.Count)
                {
                    int temp = targets[int.Parse(index)];
                    targets.Insert(int.Parse(index), - 1);
                    targets.RemoveAt((int.Parse(index) + 1));
                    shooted++;

                    for (int i = 0; i < targets.Count; i++)
                    {
                        if (targets[i] != -1)
                        {
                            if (targets[i] > temp)
                            {
                                targets[i] -= temp;
                            }
                            else
                            {
                                targets[i] += temp;
                            }
                        }
                    }
                }



                index = Console.ReadLine();
            }

            Console.Write($"Shot targets: {shooted} -> ");
            Console.Write(string.Join(" ", targets));
        }
    }
}
