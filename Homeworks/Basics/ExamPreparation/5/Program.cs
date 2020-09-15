using System;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Име на играч – текст
            //•	Брой изиграни игри – цяло число в интервала[1...10]
            //За всяка една игра се четат по два реда:
            //•	Име на играта – текст с възможности "volleyball", "tennis", "badminton"
            //•	Брой точки – цяло число в интервала[1…100]
            string playerName = Console.ReadLine();
            int playedGames = int.Parse(Console.ReadLine());
            double volleyballPoints = 0;
            int volleyballCounter = 0;
            double tennisPoints = 0;
            int tennisCounter = 0;
            double badmintonPoints = 0;
            int badmintonCounter = 0;

            for (int i = 0; i < playedGames; i++)
            {
                string gameName = Console.ReadLine();
                int points = int.Parse(Console.ReadLine());

                switch (gameName)
                {
                    case "volleyball":
                        volleyballCounter++;
                        volleyballPoints += points * 1.07;
                        break;

                    case "tennis":
                        tennisCounter++;
                        tennisPoints += points * 1.05;
                        break;

                    case "badminton":
                        badmintonCounter++;
                        badmintonPoints += points * 1.02;
                        break;

                }
            }
            double averageV = Math.Floor(volleyballPoints / volleyballCounter);
            double averageT = Math.Floor(tennisPoints / tennisCounter);
            double averageB = Math.Floor(badmintonPoints / badmintonCounter);
            double totalPoints = Math.Floor(volleyballPoints + tennisPoints + badmintonPoints);
            if (averageV >= 75 && averageT >= 75 && averageB >= 75)
            {
                Console.WriteLine($"Congratulations, {playerName}! You won the cruise games with {totalPoints} points.");
            }
            else
            {
                Console.WriteLine($"Sorry, {playerName}, you lost. Your points are only {totalPoints}.");
            }

        }
    }
}
