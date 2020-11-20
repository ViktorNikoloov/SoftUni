using _04.WildFarm.Models._Contracts.Animal.Bird;

namespace _04.WildFarm.Models.Animal.Bird
{
    public abstract class Bird : Animal, IBird
    {
        protected Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; set; }

        public override string ToString()
        => base.ToString() + $"{WingSize}, {Weight}, {FoodEaten}]";
    }
}
