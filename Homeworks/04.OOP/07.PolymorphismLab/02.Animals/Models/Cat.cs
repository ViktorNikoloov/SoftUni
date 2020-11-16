using Animals.Models.Contracts;

namespace Animals.Models
{
    public class Cat : Animal, ICat
    {
        public Cat(string name, string favouriteFood) 
            : base(name, favouriteFood)
        {

        }

        public override string ExplainSelf()
        => $"I am {Name} and my fovourite food is {FavouriteFood} MEEOW";
    }
}
