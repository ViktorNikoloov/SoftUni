using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());
            Stack<int> clothes = new Stack<int>(input);
            int racks = 0;

            while (clothes.Count != 0)
            {
                int currSumOfClothes = 0;
                while (clothes.Count != 0 && currSumOfClothes + clothes.Peek() <= capacity)
                {
                   currSumOfClothes += clothes.Pop();
                }

                racks++;
            }
            Console.WriteLine(racks);
        }
    }
}
