namespace Animals
{
    public class Tomcat : Cat
    {
        private const string GenderMaleCat = "Male";

        public Tomcat(string name, int age) 
            : base(name, age, GenderMaleCat)
        {

        }

        public override string ProduceSound()
        {
            return $"MEOW";
        }
    }
}
