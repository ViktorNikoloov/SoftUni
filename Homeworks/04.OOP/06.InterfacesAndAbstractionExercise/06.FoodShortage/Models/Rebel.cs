using _06.FoodShortage.Models.Contracts;

namespace _06.FoodShortage.Models
{
    public class Rebel : ICitizen, IRebel, IBuyer
    {
        private string name;
        private int age;
        private string group;
        private int food;

        public Rebel()
        {
            food = 0;
        }

        public Rebel(string name, int age, string group)
            :this()
        {
            Name = name;
            Age = age;
            Group = group;
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

        public string Group
        {
            get => group;
            private set
            {
                group = value;
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
            food += 5;
        }
    }
}
