using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person ivan = new Person();
            
            Person viktor = new Person(23);
            Person tanya = new Person("tanya", 26);
            
            Console.WriteLine($"Name: {ivan.Name}\nAge: {ivan.Age}");
            Console.WriteLine($"Name: {viktor.Name}\nAge: {viktor.Age}");
            Console.WriteLine($"Name: {tanya.Name}\nAge: {tanya.Age}");
        }
    }
}
