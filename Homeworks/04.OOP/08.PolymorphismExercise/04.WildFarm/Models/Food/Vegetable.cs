using _04.WildFarm.Models._Contracts.Food;

namespace _04.WildFarm.Models.Food
{
    public class Vegetable : Food, IVegetable
    {
        public Vegetable(int quantity) 
            : base(quantity)
        {

        }
    }
}
