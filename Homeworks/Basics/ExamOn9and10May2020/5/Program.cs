using System;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	На първи ред получавате брой студенти: цяло число [10-10000].
            //•	На втори ред получавате брой задачи: цяло число[1 - 1000].
            //•	На трети ред получавате енергия на трейнъра: цяло число[1 - 10000].
            int students = int.Parse(Console.ReadLine());
            int tasks = int.Parse(Console.ReadLine());
            int energy = int.Parse(Console.ReadLine());
            int totalTask = 0;
            int totalQuestions = 0;
            while (students >= 10 && energy > 0)
            {
                totalTask += tasks;
                energy += tasks * 2;
                students -= tasks;
                int questions = students * 2;
                totalQuestions += questions;
                energy -= questions * 3;

                if (students < 10)
                {
                    break;
                }
                if (energy <= 0)
                {
                    break;
                }
                double afterBreak = Math.Floor(students / 10.0);
                students += (int)afterBreak;

            }

            if (students < 10)
            {
                Console.WriteLine("The students are too few!");
                Console.WriteLine($"Problems solved: {totalTask}"); 
            }
            else
            {
                Console.WriteLine("The trainer is too tired!");
                Console.WriteLine($"Questions answered: {totalQuestions}");
            }
        }
    }
}
