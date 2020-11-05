using System;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private const string InvalidInputError = "Invalid input!";
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidInputError);
                }
              
                    name = value;

            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            private set
            {
                if (value < 0)
                {
                    throw new Exception(InvalidInputError);
                }
                
                    age = value;
            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidInputError);
                }
               
                    gender = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine(this.ProduceSound());

            return sb.ToString().Trim();

        }

        public abstract string ProduceSound();

    }
}
