namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int MagicCardDefaultDamagPoint = 5;
        private const int MagicCardDefaultHealthPoint = 80;

        public MagicCard(string name) 
            : base(name, MagicCardDefaultDamagPoint, MagicCardDefaultHealthPoint)
        {

        }
    }
}
