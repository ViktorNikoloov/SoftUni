using _04.WildFarm.Models._Contracts.Food;
using _04.WildFarm.Models.Food;

namespace _04.WildFarm.Factories
{
    public class FoodFactory
    {
        public IFoodable CreatFood(string[] animalsArgs)
        {
            string foodType = animalsArgs[0];
            int quantity = int.Parse(animalsArgs[1]);

            IFoodable food = null;

            if (foodType == "Fruit")
            {

                food = new Fruit(quantity);
            }
            else if (foodType == "Meat")
            {

                food = new Meat(quantity);
            }
            else if (foodType == "Seeds")
            {

                food = new Seeds(quantity);
            }
            else if (foodType == "Vegetable")
            {

                food = new Vegetable(quantity);
            }

            return food;
        }
    }
}
