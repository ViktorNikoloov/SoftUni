using System;

namespace _2._Football_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Резултат от първия мач – текст 
            //2.Резултат от втория мач – текст
            //3.Резултат от третия мач – текст
            int counter = 3;
            int wins = 0;
            int loses = 0;
            int drawns = 0;

            for (int i = 0; i < counter; i++)
            {
                string result = Console.ReadLine();
                int lengthOfResult = result.Length;
                int firstTeamScore = result[0];
                int secondTeamScore = result[2];

                if (firstTeamScore > secondTeamScore)
                {
                    wins++;
                }
                if (firstTeamScore < secondTeamScore)
                {
                    loses++;
                }
                if (firstTeamScore == secondTeamScore)
                {
                    drawns++;
                }
            }

            Console.WriteLine($"Team won {wins} games.");
            Console.WriteLine($"Team lost {loses} games.");
            Console.WriteLine($"Drawn games: {drawns}");
        }
    }
}
