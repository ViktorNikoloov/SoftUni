using _03.Raiding.Models.Contracts;

namespace _03.Raiding.Models
{
    public class Rogue : BaseHero, IRogue
    {
        private const int RoguePower = 80;

        public Rogue(string name)
            : base(name)
        {
            this.Power = RoguePower;

        }

        public override string CastAbility()
        => base.CastAbility() + $"hit for {Power} damage";

    }
}
