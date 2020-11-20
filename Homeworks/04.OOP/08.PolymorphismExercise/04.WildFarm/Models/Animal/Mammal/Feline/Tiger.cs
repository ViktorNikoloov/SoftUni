using _04.WildFarm.Models._Contracts.Animal.Mammal.Feline;

namespace _04.WildFarm.Models.Animal.Mammal.Feline
{
    public class Tiger : Feline, ITiger
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {

        }

        public override string ProduceSound()
        => "ROAR!!!";
    }
}
