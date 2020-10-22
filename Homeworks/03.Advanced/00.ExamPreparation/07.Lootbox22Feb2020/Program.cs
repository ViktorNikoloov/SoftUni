using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Lootbox22Feb2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstBoxInput= Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondBoxInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> firstBox = new Queue<int>(firstBoxInput);
            Stack<int> secondBox = new Stack<int>(secondBoxInput);
            int items = 0;
            
            while (firstBox.Count != 0 && secondBox.Count != 0)
            {
                int sum = firstBox.Peek() + secondBox.Peek();
                if (sum % 2 == 0)
                {
                    items += sum;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }


            }

            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (items >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {items}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {items}");

            }
        }
    }
}
