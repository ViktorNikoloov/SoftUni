using _05.BirthdayCelebrations.Models.Contracts;

namespace _05.BirthdayCelebrations
{
    public class Citizen : ICitizen
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
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

        public override string ToString()
        => Birthdate.ToString();
    }
}
