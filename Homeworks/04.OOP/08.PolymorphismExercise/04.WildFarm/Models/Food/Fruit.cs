using _04.WildFarm.Models._Contracts.Food;

namespace _04.WildFarm.Models.Food
{
    public class Fruit : Food, IFruit
    {
        public Fruit(int quantity) 
            : base(quantity)
        {

        }
    }
}
