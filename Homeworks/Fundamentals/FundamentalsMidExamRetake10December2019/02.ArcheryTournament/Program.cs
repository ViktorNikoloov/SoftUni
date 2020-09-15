using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ArcheryTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int points = 0;

            string gameOver = Console.ReadLine();
            while (gameOver != "Game over")
            {
                string[] command = gameOver.Split("@", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int startIndex = int.Parse(command[1]);
                int length = int.Parse(command[2]);

                if (0 > startIndex || startIndex > targets.Count - 1)
                {
                    continue;
                }

                if (command[0] == "Shoot Left") // {start index} {length}
                {

                    if ((startIndex + length) <= targets.Count - 1)
                    {
                        startIndex = targets.Count - 1;
                    }

                    targets[startIndex - length + 1] -= 5;
                    points += 5;

                }
                else if (command[0] == "Shoot Right")
                {
                    if ((startIndex - length) < 0)
                    {
                        startIndex = 0;
                    }

                    targets[startIndex + length - 1] -= 5;
                    points += 5;

                }
                else if (command[0] == "Reverse")
                {
                    targets.Reverse();
                }

                gameOver = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" - ", targets));
            Console.WriteLine("Iskren finished the archery tournament with {points}!");
        }
    }
}
