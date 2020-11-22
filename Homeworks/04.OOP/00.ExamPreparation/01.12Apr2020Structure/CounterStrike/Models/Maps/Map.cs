using System.Collections.Generic;
using System.Linq;

using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players.Where(terrorist => terrorist.GetType() == typeof(Terrorist)).ToList();

            var counterTerrorists = players.Where(counterTerrorist => counterTerrorist.GetType() == typeof(CounterTerrorist)).ToList();

            while (terrorists.Any(x => x.IsAlive) && counterTerrorists.Any(x => x.IsAlive))
            {
                foreach (var terrorist in terrorists.Where(t => t.IsAlive))
                {
                    foreach (var counterTerrorist in counterTerrorists.Where(c => c.IsAlive))
                    {
                        counterTerrorist.TakeDamage(terrorist.Gun.Fire());
                    }
                }

                foreach (var counterTerrorist in counterTerrorists.Where(c => c.IsAlive))
                {
                    foreach (var terrorist in terrorists.Where(t => t.IsAlive))
                    {
                        terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                    }
                }
            }

            if (terrorists.Any(t=>t.IsAlive))
            {
                return "Terrorist wins!";
            }
            else
            {
               return "Counter Terrorist wins!";
            }
        }
    }
}
