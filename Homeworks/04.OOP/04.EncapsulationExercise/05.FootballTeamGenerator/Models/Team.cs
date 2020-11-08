using System;
using System.Collections.Generic;
using System.Linq;
using _05.FootballTeamGenerator.Common;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private const string Remove_Player_Exs_Msg = "Player {0} is not in {1} team.";
        private const string Missing_Team_Exs_Msg = "Team {0} does not exist.";

        private string name;
        private readonly List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalExeptions.Name_Exs_Msg);
                }

                name = value;
            }
        }
        public IReadOnlyCollection<Player> Players
        => players.AsReadOnly();
        
        public void AddPlayer(Player player, string team)
        {
            if (this.Name != team)
            {
                throw new ArgumentException(string.Format(Missing_Team_Exs_Msg, team));
            }

            players.Add(player);

        }

        public void RemovePlayer(string name, string team)
        {
            bool isPlayerAndTheTeamExist = players.Any(x => x.Name == name);
            if (this.Name != team)
            {
                throw new ArgumentException(string.Format(Missing_Team_Exs_Msg, team));
            }
            if (!isPlayerAndTheTeamExist)
            {
                throw new ArgumentException(string.Format(Remove_Player_Exs_Msg, name, team));
            }

            players.RemoveAll(x => x.Name == name);
        }

        public int ShowRating(string team)
        {
            if (this.Name != team)
            {
                throw new ArgumentException(string.Format(Missing_Team_Exs_Msg, team));
            }

            double totalStat = 0;
            foreach (var player in players)
            {
                totalStat += player.SkillLevel;
            }

            if (totalStat != 0)
            {
                totalStat = totalStat / players.Count;
            }

            return (int)Math.Round(totalStat);
        }

       


    }
}
