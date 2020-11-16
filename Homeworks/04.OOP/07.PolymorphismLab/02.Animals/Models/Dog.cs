namespace Animals.Models
{
    public class Dog : Animal, Idog
    {
        public Dog(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        => $"I am {Name} and my fovourite food is {FavouriteFood} DJAAF";
    }
}
