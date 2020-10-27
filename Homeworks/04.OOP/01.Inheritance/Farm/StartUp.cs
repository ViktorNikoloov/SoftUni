using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal();
            animal.Eat();

            Dog dog = new Dog();
            dog.Eat();
            dog.Bark();
        }
    }
}
