using System;

namespace _5._Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Брой турнири, в които е участвал – цяло число в интервала [1…20] 
            //•	Начален брой точки в ранглистата - цяло число в интервала[1...4000]
            //За всеки турнир се прочита отделен ред:
            //•	Достигнат етап от турнира – текст – "W", "F" или "SF"
            int tournaments = int.Parse(Console.ReadLine());
            int startPoints = int.Parse(Console.ReadLine());
            int totalPoints = startPoints;
            int currPoints = 0;
            int wins = 0;

            //За всеки турнир се прочита отделен ред:
            //•	Достигнат етап от турнира – текст – "W", "F" или "SF"
            for (int i = 0; i < tournaments; i++)
            {
                string command = Console.ReadLine();

                //W - ако е победител получава 2000 точки
                //F - ако е финалист получава 1200 точки
                //SF - ако е полуфиналист получава 720 точки
                if (command == "W")
                {
                    totalPoints += 2000;
                    currPoints += 2000;
                    wins++;
                }
                else if (command == "F")
                {
                    totalPoints += 1200;
                    currPoints += 1200;

                }
                else
                {
                    totalPoints += 720;
                    currPoints += 720;

                }

            }

            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {Math.Floor(1.0 * currPoints / tournaments)}");
            Console.WriteLine($"{1.0 * wins / tournaments * 100:f2}%");

        }
    }
}
