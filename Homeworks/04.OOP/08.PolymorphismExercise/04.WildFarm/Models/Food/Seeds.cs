using _04.WildFarm.Models._Contracts.Food;

namespace _04.WildFarm.Models.Food
{
    public class Seeds : Food, ISeeds
    {
        public Seeds(int quantity) : base(quantity)
        {

        }
    }
}
