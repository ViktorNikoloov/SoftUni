using _04.BorderControl.Models.Contracts;

namespace _04.BorderControl.Models
{
    public class Citizen : ICitizen
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
            }
        }

        public int Age 
        {
            get => age;
            set
            {
                age = value;
            }
        }

        public string Id
        {
            get => id;
            set
            {
                id = value;
            }
        }
    }
}
