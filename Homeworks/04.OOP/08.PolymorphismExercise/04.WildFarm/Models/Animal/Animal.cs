using System;

using _04.WildFarm.Common;
using _04.WildFarm.Models._Contracts.Animal;

namespace _04.WildFarm.Models.Animal
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract string ProduceSound();

        public void FeedTheAnimal(string animalType, string foodType, int quantity)
        {
            if (IsEatable(animalType, foodType))
            {
                switch (animalType)
                {
                    case "Hen":
                        Weight += quantity * WeightIncrease.Hen;
                        FoodEaten = quantity;
                        break;

                    case "Owl":
                        Weight += quantity * WeightIncrease.Owl;
                        FoodEaten = quantity;
                        break;

                    case "Mouse":
                        Weight += quantity * WeightIncrease.Mouse;
                        FoodEaten = quantity;
                        break;

                    case "Cat":
                        Weight += quantity * WeightIncrease.Cat;
                        FoodEaten = quantity;
                        break;

                    case "Dog":
                        Weight += quantity * WeightIncrease.Dog;
                        FoodEaten = quantity;
                        break;

                    case "Tiger":
                        Weight += quantity * WeightIncrease.Tiger;
                        FoodEaten = quantity;
                        break;
                }

                throw new ArgumentException(string.Format(ExceptionMessages.NotEatableMsg, animalType, foodType));
            }
        }

        private bool IsEatable(string animalType, string foodType)
        {
            bool isEatable = false;
            switch (animalType)
            {
                case "Hen":
                    switch (foodType)
                    {
                        case "Friut":
                        case "Meat":
                        case "Seeds":
                        case "Vegetable":
                            isEatable = true;
                            break;
                    }
                    break;

                case "Mice":
                    switch (foodType)
                    {
                        case "Friut":
                        case "Vegetable":
                            isEatable = true;
                            break;
                    }
                    break;

                case "Cat":
                    switch (foodType)
                    {
                        case "Meat":
                        case "Vegetable":
                            isEatable = true;
                            break;
                    }
                    break;

                case "Owl":
                case "Dog":
                case "Tiger":
                    switch (foodType)
                    {
                        case "Meat":
                            isEatable = true;
                            break;
                    }
                    break;

            }

            return isEatable;

        }

        public override string ToString()
        => $"{this.GetType().Name} [{Name}, ";
    }
}
