using _03.Raiding.Models.Contracts;

namespace _03.Raiding.Models
{
    public class Paladin : BaseHero, IPaladin
    {
        private const int PaladinPower = 100;

        public Paladin(string name)
            : base(name)
        {
            this.Power = PaladinPower;
        }

        public override string CastAbility()
        => base.CastAbility() + $"healed for {Power}";


    }
}
