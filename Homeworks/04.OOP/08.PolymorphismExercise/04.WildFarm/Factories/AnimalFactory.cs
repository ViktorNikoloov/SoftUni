using _04.WildFarm.Models._Contracts.Animal;
using _04.WildFarm.Models.Animal.Bird;
using _04.WildFarm.Models.Animal.Mammal;
using _04.WildFarm.Models.Animal.Mammal.Feline;

namespace _04.WildFarm.Factories
{
    public class AnimalFactory
    {
        public IAnimal CreatAnimal(string[] animalsArgs)
        {
            string animalType = animalsArgs[0];
            string name = animalsArgs[1];
            double weight = double.Parse(animalsArgs[2]);

            IAnimal animal = null;

            if (animalType == "Mouse")
            {
                string livingRegion = animalsArgs[3];

                animal = new Mouse(name, weight, livingRegion);
            }
            else if (animalType == "Dog")
            {
                string livingRegion = animalsArgs[3];

                animal = new Dog(name, weight, livingRegion);
            }
            else if (animalType == "Hen")
            {
                double wingSize = double.Parse(animalsArgs[3]);

                animal = new Hen(name, weight, wingSize);
            }
            else if (animalType == "Owl")
            {
                double wingSize = double.Parse(animalsArgs[3]);

                animal = new Owl(name, weight, wingSize);
            }
            else if (animalType == "Cat")
            {
                string livingRegion = animalsArgs[3];
                string breed = animalsArgs[4];

                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (animalType == "Tiger")
            {
                string livingRegion = animalsArgs[3];
                string breed = animalsArgs[4];

                animal = new Tiger(name, weight, livingRegion, breed);
            }


            return animal;
        }
    }
}
