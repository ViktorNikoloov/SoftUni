using _04.WildFarm.Models._Contracts.Food;

namespace _04.WildFarm.Models.Food
{
    public abstract class Food : IFoodable
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; set; }
    }
}
