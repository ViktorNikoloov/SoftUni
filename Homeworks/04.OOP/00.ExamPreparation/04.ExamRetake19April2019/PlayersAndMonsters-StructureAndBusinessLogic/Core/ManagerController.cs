namespace PlayersAndMonsters.Core
{
    using System.Linq;
    using System.Text;
    using Contracts;

    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Core.Factories;

    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.BattleFields;

    using PlayersAndMonsters.Models.Players.Contracts;

    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Repositories;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository playerRepository;
        private ICardRepository cardRepository;

        private readonly ICardFactory cardFactory;
        private readonly IPlayerFactory playerFactory;

        private IPlayer player;
        private ICard card;

        public ManagerController()
        {
            cardFactory = new CardFactory();
            playerFactory = new PlayerFactory();

            playerRepository = new PlayerRepository();
            cardRepository = new CardRepository();
        }

        public string AddPlayer(string type, string username)
        {
            player = playerFactory.CreatePlayer(type, username);

            playerRepository.Add(player);
            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            card = cardFactory.CreateCard(type, name);

            cardRepository.Add(card);
            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            player = playerRepository.Players.FirstOrDefault(x => x.Username == username);
            card = cardRepository.Cards.FirstOrDefault(x => x.Name == cardName);

            player.CardRepository.Add(card);

            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = playerRepository.Players.FirstOrDefault(x => x.Username == attackUser);
            IPlayer enemy = playerRepository.Players.FirstOrDefault(x => x.Username == enemyUser);

            BattleField battleField = new BattleField();
            battleField.Fight(attacker, enemy);

            return $"Attack user health {attacker.Health} - Enemy user health {enemy.Health}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} - Cards {player.CardRepository.Count}");

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }
                sb.AppendLine("###");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
