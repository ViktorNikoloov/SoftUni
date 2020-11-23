using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using CounterStrike.Utilities.Messages;
using CounterStrike.Core.Contracts;

using CounterStrike.Repositories;
using CounterStrike.Repositories.Contracts;

using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;

using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;

using CounterStrike.Models.Players.Contracts;
using CounterStrike.Models.Players;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IGun> guns;
        private readonly IRepository<IPlayer> players;
        private readonly IMap map;

        private IGun gun;
        private IPlayer player;

        public Controller()
        {
            guns = new GunRepository();
            players = new PlayerRepository();
            map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            if (type == "Pistol")
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name, bulletsCount);

            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            guns.Add(gun);
            return $"Successfully added gun {gun.Name}.";
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
           IGun gunToAdd = guns.FindByName(gunName);
            if (gunToAdd == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            if (type == "Terrorist")
            {
                player = new Terrorist(username, health, armor, gunToAdd);
            }
            else if (type == "CounterTerrorist")
            {
                player = new CounterTerrorist(username, health, armor, gunToAdd);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            players.Add(player);
            return $"Successfully added player {player.Username}.";
        }

        public string Report()
        {
            var allPlayers = players.Models
                .OrderBy(t =>t.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(u => u.Username);

            StringBuilder sb = new StringBuilder();

            foreach (var player in allPlayers)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();

        }

        public string StartGame()
        {
            ICollection<IPlayer> аlivePlayers = players.Models.Where(ap => ap.IsAlive).ToList();

            return map.Start(аlivePlayers);
        }
    }
}
