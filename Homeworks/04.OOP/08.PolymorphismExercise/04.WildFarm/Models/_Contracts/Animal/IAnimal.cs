using _04.WildFarm.Models._Contracts.Food;

namespace _04.WildFarm.Models._Contracts.Animal
{
    public interface IAnimal
    {
        public string Name { get; }

        public double Weight { get; }

        public int FoodEaten { get; }

        public string ProduceSound();

        public void FeedTheAnimal(IAnimal animal, IFoodable food);
    }
}
