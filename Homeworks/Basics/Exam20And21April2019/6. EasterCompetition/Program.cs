using System;

namespace _6._EasterCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            //Първоначално от конзолата се прочита броя на козунаците – цяло число в интервала[1… 100]
            int easterBread = int.Parse(Console.ReadLine());
            int maxScore = int.MinValue;
            string MaxScoreChef = "";

            //След това за всеки козунак се прочита:
            for (int i = 0; i < easterBread; i++)
            {
                //Името на пекаря, който е направил козунака – текст
                string chefName = Console.ReadLine();
                string comand = Console.ReadLine();
                int finalScore = 0;

                while (comand != "Stop")
                {
                    
                    //До получаване на командата "Stop" се прочита
                    //оценка за козунак от един човек  – цяло число в интервала[1... 10]
                    int score = int.Parse(comand);
                    finalScore += score;
                    comand = Console.ReadLine();

                }

                Console.WriteLine($"{chefName} has {finalScore} points.");
                if (finalScore > maxScore)
                {
                    maxScore = finalScore;
                    MaxScoreChef = chefName;
                    Console.WriteLine($"{chefName} is the new number 1!");
                }
                finalScore = 0;
            }

            Console.WriteLine($"{MaxScoreChef} won competition with {maxScore} points!");

        }
    }
}
