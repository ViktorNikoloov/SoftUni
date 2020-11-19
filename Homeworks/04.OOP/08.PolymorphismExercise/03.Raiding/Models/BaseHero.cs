using _03.Raiding.Models.Contracts;

namespace _03.Raiding.Models
{
    public abstract class BaseHero : IHero
    {
        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public int Power { get; protected set; }

        public virtual string CastAbility()
        => $"{this.GetType().Name} - {Name} ";
        

    }
}
