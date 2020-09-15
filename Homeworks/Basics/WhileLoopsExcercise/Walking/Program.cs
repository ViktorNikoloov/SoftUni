using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;
            int stepsToGoal = 0;

            while (goal > stepsToGoal)
            {
                string input = Console.ReadLine();
                if (input == "Going home")
                {
                    input = Console.ReadLine();
                    stepsToGoal += int.Parse(input);
                    break;
                }
                stepsToGoal += int.Parse(input);
                

            }

            if (stepsToGoal >= goal)
            {
            Console.WriteLine("Goal reached! Good job!");
            }
            else
            {
                Console.WriteLine($"{goal - stepsToGoal} more steps to reach goal.");
            }
        }
    }
}
