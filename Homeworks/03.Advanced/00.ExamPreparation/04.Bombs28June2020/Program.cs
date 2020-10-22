using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Bombs28June2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] effectsInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] casingsInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> bombEffects = new Queue<int>(effectsInput);
            Stack<int> bombCasings = new Stack<int>(casingsInput);

            int daturaBombs = 0; //40
            int cherryBombs = 0; //60
            int smokeDecoy = 0; //120


            while (bombEffects.Count != 0 && bombCasings.Count != 0)
            {
                if (daturaBombs >= 3 && cherryBombs >= 3 && smokeDecoy >= 3)
                {
                    break;
                }
                int currSum = bombEffects.Peek() + bombCasings.Peek();

                if (currSum == 40)
                {
                    daturaBombs++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else if (currSum == 60)
                {
                    cherryBombs++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else if (currSum == 120)
                {
                    smokeDecoy++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else
                {
                    bombCasings.Push(bombCasings.Pop() - 5);
                }

            }

            Dictionary<string, int> allOrderedBombs = new Dictionary<string, int>()
            {
                {"Datura Bombs", daturaBombs},
                {"Cherry Bombs", cherryBombs},
                {"Smoke Decoy Bombs", smokeDecoy}
            }
            .OrderBy(x => x.Key).
            ToDictionary(x => x.Key, y => y.Value);

            if (daturaBombs >= 3 && cherryBombs >= 3 && smokeDecoy >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count != 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasings.Count != 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in allOrderedBombs)
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
