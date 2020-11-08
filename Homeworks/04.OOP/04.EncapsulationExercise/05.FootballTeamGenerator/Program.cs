using System;

namespace _05.FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Team team = null;

            string[] input = Console.ReadLine().Split(";");
            while (input[0] != "END")
            {

                string command = input[0];
                try
                {

                    if (command == "Add")
                    {
                        string teamName = input[1];

                        string playerName = input[2];
                        int endurance = int.Parse(input[3]);
                        int sprint = int.Parse(input[4]);
                        int dribble = int.Parse(input[5]);
                        int passing = int.Parse(input[6]);
                        int shooting = int.Parse(input[7]);

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        team.AddPlayer(player, teamName);
                    }
                    else if (command == "Remove")
                    {
                        string teamName = input[1];

                        string playerName = input[2];
                        team.RemovePlayer(playerName, teamName);
                    }
                    else if (command == "Rating")
                    {
                        string teamName = input[1];

                        Console.WriteLine($"{team.Name} - {team.ShowRating(teamName)}");
                    }
                    else
                    {
                        if (input.Length <= 1)
                        {
                            team = new Team(input[0]);
                        }
                        else
                        {
                            team = new Team(input[1]);
                        }

                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                input = Console.ReadLine().Split(";");
            }

        }
    }
}
