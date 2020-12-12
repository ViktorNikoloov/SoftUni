using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Repositories;

using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Models.Players;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private IPlayer player;

        public IPlayer CreatePlayer(string type, string username)
        {
            if (type == "Beginner")
            {
                player = new Beginner(new CardRepository(), username);
            }
            else
            {
                player = new Advanced(new CardRepository(), username);
            }

            return player;
        }

    }
}
