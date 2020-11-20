using _04.WildFarm.Models._Contracts.Animal.Mammal;

namespace _04.WildFarm.Models.Animal.Mammal
{
    public abstract class Mammal : Animal, IMammal
    {
        protected Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; set; }

        public override string ToString()
        =>base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
