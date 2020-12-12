namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int MagicCardDefaultDamagPoint = 120;
        private const int MagicCardDefaultHealthPoint = 5;

        public TrapCard(string name)
            : base(name, MagicCardDefaultDamagPoint, MagicCardDefaultHealthPoint)
        {

        }
    }
}
