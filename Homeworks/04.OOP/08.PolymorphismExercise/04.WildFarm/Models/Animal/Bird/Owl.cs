using _04.WildFarm.Models._Contracts.Animal.Bird;

namespace _04.WildFarm.Models.Animal.Bird
{
    public class Owl : Bird, IOwl
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {

        }

        public override string ProduceSound()
        => "Hoot Hoot";
    }
}
