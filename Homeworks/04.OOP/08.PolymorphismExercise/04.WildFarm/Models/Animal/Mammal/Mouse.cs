using _04.WildFarm.Models._Contracts.Animal.Mammal;

namespace _04.WildFarm.Models.Animal.Mammal
{
    public class Mouse : Mammal, IMouse
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {

        }

        public override string ProduceSound()
        => "Squeak";
    }
}
