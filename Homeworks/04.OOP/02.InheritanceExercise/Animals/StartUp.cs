using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while (command != "Beast!")
            {
                string[] animalInfo = Console.ReadLine().Split();

                string animalType = command;
                string animalName = animalInfo[0];
                int animalAge = int.Parse(animalInfo[1]);
                string animalGender = animalInfo[2];

                Animal animal = null;

                if (animalType == "Cat")
                {
                    animal = new Cat(animalName, animalAge, animalGender);
                }
                else if (animalType == "Dog")
                {
                    animal = new Dog(animalName, animalAge, animalGender);

                }
                else if (animalType == "Frog")
                {
                    animal = new Frog(animalName, animalAge, animalGender);

                }
                else if (animalType == "Kittens")
                {
                    animal = new Kitten(animalName, animalAge);

                }
                else if (animalType == "Tomcat")
                {
                    animal = new Tomcat(animalName, animalAge);

                }

                Console.WriteLine(animal.ToString());

                command = Console.ReadLine();
            }

        }
    }
}
