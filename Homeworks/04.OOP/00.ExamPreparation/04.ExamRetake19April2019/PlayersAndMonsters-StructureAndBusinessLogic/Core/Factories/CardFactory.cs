using System;

using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        private ICard card;

        public CardFactory()
        {

        }

        public ICard CreateCard(string type, string name)
        {
            if (type =="Magic")
            {
                card = new MagicCard(name);
            }
            else
            {
                card = new TrapCard(name);

            }

            return card;
        }
    }
}
