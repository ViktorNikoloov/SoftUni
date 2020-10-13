using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths19August2020
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] roses = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			int[] lilies = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

			Queue<int> rosesQueue = new Queue<int>(roses);
			Stack<int> liliesStack = new Stack<int>(lilies);

			int flowerWreaths = 0;
			int storedFlowers = 0;

			while (rosesQueue.Count != 0 && liliesStack.Count != 0)
			{
				int currRoses = rosesQueue.Peek();
				int currLilies = liliesStack.Peek();

				if (currRoses + currLilies == 15)
				{
					flowerWreaths++;
					rosesQueue.Dequeue();
					liliesStack.Pop();
				}
				else if (currRoses + currLilies > 15)
				{
					liliesStack.Push(liliesStack.Pop() - 2);
				}
				else
				{
					storedFlowers += liliesStack.Pop() + rosesQueue.Dequeue();
				}
			}

			flowerWreaths += storedFlowers / 15;

			if (flowerWreaths >= 5)
			{
				Console.WriteLine($"You made it, you are going to the competition with {flowerWreaths} wreaths!");
			}
			else
			{
				Console.WriteLine($"You didn't make it, you need {5 - flowerWreaths} wreaths more!");
			}
		}
	}
}
