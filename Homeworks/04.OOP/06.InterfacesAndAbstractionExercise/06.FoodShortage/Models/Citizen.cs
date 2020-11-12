using _06.FoodShortage.Models.Contracts;

namespace _06.FoodShortage
{
    public class Citizen : ICitizen, IBirthable, IIdentifiable, IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;
        private int food;

        public Citizen()
        {
            food = 0;
        }

        public Citizen(string name, int age, string id, string birthdate)
            :this()
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name
        {
            get => name;
            private set
            {
                name = value;
            }
        }

        public int Age 
        {
            get => age;
            private set
            {
                age = value;
            }
        }

        public string Id
        {
            get => id;
            private set
            {
                id = value;
            }
        }

        public string Birthdate
        {
            get => birthdate;
            private set
            {
                birthdate = value;
            }
        }

        public int Food
        {
            get => food;
            private set
            {
                food = value;
            }
        }

        public void BuyFood()
        {
            food += 10;
        }

        public override string ToString()
        => Birthdate.ToString();
    }
}
