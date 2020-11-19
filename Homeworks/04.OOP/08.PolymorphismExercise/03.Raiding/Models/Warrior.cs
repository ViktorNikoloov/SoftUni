using _03.Raiding.Models.Contracts;

namespace _03.Raiding.Models
{
    public class Warrior : BaseHero, IWarrior
    {
        private const int WarriorPower = 100;

        public Warrior(string name)
            : base(name)
        {
            this.Power = WarriorPower;

        }

        public override string CastAbility()
        => base.CastAbility() + $"hit for {Power} damage";


    }
}
