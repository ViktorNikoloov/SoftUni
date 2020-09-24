using System;

namespace _4.EasterEggsBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstPlayerEggs = int.Parse(Console.ReadLine());
            int secondPlayerEggs = int.Parse(Console.ReadLine());
            int firstPlayerScore = firstPlayerEggs;
            int secondPlayerScore = secondPlayerEggs;
            string endOfGame = "";

            while (endOfGame != "End of battle")
            {
                string oneOrTwo = endOfGame;

                if (secondPlayerScore <= 0)
                {
                    break;
                }
                if (firstPlayerScore <= 0)
                {
                    break;
                }
                if (oneOrTwo == "one")
                {
                    secondPlayerScore--;
                }
                if (oneOrTwo == "two")
                {
                    firstPlayerScore--;
                }

                endOfGame = Console.ReadLine();

            }

            if (endOfGame == "End of battle")
            {
                Console.WriteLine($"Player one has {firstPlayerScore} eggs left.");
                Console.WriteLine($"Player two has {secondPlayerScore} eggs left.");
            }
            else if (firstPlayerScore <= 0)
            {
                Console.WriteLine($"Player one is out of eggs. Player two has {secondPlayerScore} eggs left.");
            }
            else
            {
                Console.WriteLine($"Player two is out of eggs. Player one has {firstPlayerScore} eggs left.");
            }

        }
    }
}
