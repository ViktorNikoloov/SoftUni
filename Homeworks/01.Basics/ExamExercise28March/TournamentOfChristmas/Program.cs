using System;

namespace TournamentOfChristmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double allDaysMoney = 0;
            int wins = 0;
            int loses = 0;

            double currDayMoney = 0;
            int currWins = 0;
            int currLoses = 0;
            for (int i = 0; i < days; i++)
            {
                while (true)
                {
                   
                    string sportOrFinish = Console.ReadLine();
                    if (sportOrFinish == "Finish")
                    {
                        if (currWins > currLoses)
                        {
                            currDayMoney *= 1.1;
                            allDaysMoney += currDayMoney;
                            currDayMoney = 0;
                            currLoses = 0;
                            currWins = 0;
                            
                        }
                        else
                        {
                            allDaysMoney += currDayMoney;
                            currDayMoney = 0;
                            currLoses = 0;
                            currWins = 0;
                        }
                        
                        break;
                    }

                    string winOrLose = Console.ReadLine();
                    
                    
                    if (winOrLose == "win")
                    {
                        currWins++;
                        wins++;
                        currDayMoney += 20;
                    }
                    if (winOrLose == "lose")
                    {
                        currLoses++;
                        loses++;
                    }
                    
                }
            }
            if (wins > loses)
            {
                allDaysMoney *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {allDaysMoney:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {allDaysMoney:f2}");
            }
        }
    }
}
