using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasksValues = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] threadsValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int taskToBeKilled = int.Parse(Console.ReadLine());

            Queue<int> threads = new Queue<int>(threadsValues);
            Stack<int> tasks = new Stack<int>(tasksValues);

            while (true)
            {
                int currThread = threads.Peek();
                int currTask = tasks.Peek();

                if (currTask == taskToBeKilled)
                {
                    Console.WriteLine($"Thread with value {currThread} killed task {taskToBeKilled}");
                    Console.WriteLine(string.Join(" ", threads));
                    return;
                }

                if (currThread >= currTask)
                {
                    currThread = threads.Dequeue();
                    currTask = tasks.Pop();
                }
                else if (currThread < currTask)
                {
                    currThread = threads.Dequeue();
                }

            }

        }
    }
}
