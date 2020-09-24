using System;

namespace _4._Game_Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Име на първия играч - текст
            //Име на втория играч -текст
            string firstPlayerName = Console.ReadLine();
            int firstTotalScore = 0;
            string secondPlayerName = Console.ReadLine();
            int secondTotalScore = 0;

            string firstPlayerCard = Console.ReadLine();
            while (firstPlayerCard != "End of game")
            {
                int firstPlayerScore = int.Parse(firstPlayerCard);
                int secondPlayerScore = int.Parse(Console.ReadLine());

                if (firstPlayerScore > secondPlayerScore)
                {
                    firstTotalScore += firstPlayerScore - secondPlayerScore;
                }
                else if (firstPlayerScore < secondPlayerScore)
                {
                    secondTotalScore += secondPlayerScore - firstPlayerScore;
                }
                else
                {
                    int firstFinalCard = int.Parse(Console.ReadLine());
                    int secondFinalCard = int.Parse(Console.ReadLine());
                    if (firstFinalCard > secondFinalCard)
                    {
                        Console.WriteLine("Number wars!");
                        Console.WriteLine($"{firstPlayerName} is winner with {firstTotalScore} points");
                    }
                    else //if (firstPlayerScore < secondPlayerScore)
                    {
                        Console.WriteLine("Number wars!");
                        Console.WriteLine($"{secondPlayerName} is winner with {secondTotalScore} points");
                    }

                    break;
                }

                firstPlayerCard = Console.ReadLine();
            }

            if (firstPlayerCard == "End of game")
            {
                //                •	"{име на първия играч} has {брой натрупани точки за първия играч} points"
                //•	"{име на втория играч} has {брой натрупани точки за втория играч} points"\
                Console.WriteLine($"{firstPlayerName} has {firstTotalScore} points");
                Console.WriteLine($"{secondPlayerName} has {secondTotalScore} points");


            }
        }
    }
}
