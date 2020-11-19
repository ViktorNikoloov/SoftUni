using _03.Raiding.Models.Contracts;

namespace _03.Raiding.Models
{
    public class Druid : BaseHero, IDruid
    {
        private const int DruidPower = 80;

        public Druid(string name)
            : base(name)
        {
            this.Power = DruidPower;

        }

        public override string CastAbility()
        => base.CastAbility() + $"healed for {Power}";


    }
}
