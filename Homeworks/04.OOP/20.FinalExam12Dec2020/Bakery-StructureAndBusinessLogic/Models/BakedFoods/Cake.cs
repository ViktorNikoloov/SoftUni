namespace Bakery.Models.BakedFoods
{
    public class Cake : BakedFood
    {
        private const int DefaultCakePortion = 245;

        public Cake(string name, decimal price) 
            : base(name, DefaultCakePortion, price)
        {

        }
    }
}
