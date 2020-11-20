using System;
using System.Collections.Generic;
using _04.WildFarm.Factories;
using _04.WildFarm.IO.Contracts;
using _04.WildFarm.Models._Contracts.Animal;
using _04.WildFarm.Models._Contracts.Food;

namespace _04.WildFarm
{
    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private ICollection<IAnimal> animals;
        private readonly AnimalFactory animalFactory;
        private readonly FoodFactory foodFactory;

        private IAnimal animal;
        private IFoodable food;

        private Engine()
        {
            animals = new List<IAnimal>();
            animalFactory = new AnimalFactory();
            foodFactory = new FoodFactory();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;
            while ((command = reader.ReadLine()) != "End")
            {
                string[] animalArgs = command.Split();
                animal = animalFactory.CreatAnimal(animalArgs);
                animal.FoodEaten += 1;
                if (animal != null)
                {
                    animals.Add(animal);
                }

                string[] foodArgs = reader.ReadLine().Split();
                food = foodFactory.CreatFood(foodArgs);

                writer.WriteLine(animal.ProduceSound());
                try
                {
                    animal.FeedTheAnimal(animalArgs[0], foodArgs[0], int.Parse(foodArgs[1]));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                foreach (var animal in animals)
                {
                    writer.WriteLine(animal.ToString());
                }
            }
        }

    }
}
