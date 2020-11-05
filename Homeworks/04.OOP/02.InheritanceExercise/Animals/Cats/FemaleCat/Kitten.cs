namespace Animals
{
    public class Kitten : Cat
    {
        private const string GenderFemaleCat = "Female";

        public Kitten(string name, int age) 
            : base(name, age, GenderFemaleCat)
        {

        }
        
        public override string ProduceSound()
        {
            return $"Meow";
        }
    }
}
