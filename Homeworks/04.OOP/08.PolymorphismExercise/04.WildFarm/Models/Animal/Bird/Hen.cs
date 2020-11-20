using _04.WildFarm.Models._Contracts.Animal.Bird;

namespace _04.WildFarm.Models.Animal.Bird
{
    public class Hen : Bird, IHen
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {

        }

        public override string ProduceSound()
        => "Cluck";
    }
}
