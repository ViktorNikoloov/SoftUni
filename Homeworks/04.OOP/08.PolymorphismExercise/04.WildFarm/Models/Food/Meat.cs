using _04.WildFarm.Models._Contracts.Food;

namespace _04.WildFarm.Models.Food
{
    public class Meat : Food, IMeat
    {
        public Meat(int quantity) 
            : base(quantity)
        {

        }
    }
}
