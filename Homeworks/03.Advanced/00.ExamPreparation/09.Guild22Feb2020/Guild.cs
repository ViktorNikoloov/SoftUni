using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Guild
{
    public class Guild
    {
        private List<Player> players;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            players = new List<Player>();
        }

        public int Count
            => players.Count;

        public string Name { get; set; }

        public int Capacity { get; set; }

        //•	Method AddPlayer(Player player) - adds an entity to the roster if there is room for it
        public void AddPlayer(Player player)
        {
            if (players.Count != Capacity)
            {
                players.Add(player);
            }
        }

        //•	Method RemovePlayer(string name) - removes a player by given name, if such exists, and returns bool
        public bool RemovePlayer(string name)
        {
            Player player = players.FirstOrDefault(x => x.Name == name);
            return players.Remove(player);
        }

        //•	Method PromotePlayer(string name) - promote (set his rank to "Member") the first player with the given name.
        //If the player is already a "Member", do nothing.
        public void PromotePlayer(string name)
        {
            Player player = players.FirstOrDefault(x => x.Name == name);

            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        //•	Method DemotePlayer(string name)- demote (set his rank to "Trial") the first player with the given name. 
        //If the player is already a "Trial",  do nothing.
        public void DemotePlayer(string name)
        {
            Player player = players.FirstOrDefault(x => x.Name == name);

            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        //•	Method KickPlayersByClass(string class) - removes all the players by the given class and returns all players from that class as an array
        public Player[] KickPlayersByClass(string @class)
        {
            Player[] kickPlayers = players.Where(x => x.Class == @class).ToArray();
            players.RemoveAll(x => x.Class == @class);

            return kickPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in players)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }

    }
}
