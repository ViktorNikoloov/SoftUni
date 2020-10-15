using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace _5.FilterByAge
{
    class Program
    {
        class Person
        {
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public string Name { get; set; }

            public int Age { get; set; }

        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people[i] = new Person(input[0], int.Parse(input[1]));
            }

            string condition = Console.ReadLine();// - "younger" or "older"
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine(); // - "name", "age" or "name age"

            Func<Person, bool> ConditionDelegate = GetCondition(condition, age);
            Action<Person> PrintDelegate = GetPrint(format);

            foreach (var person in people)
            {
                if (ConditionDelegate(person))
                {
                    PrintDelegate(person);
                }
            }

        }

        static Action<Person> GetPrint(string format)
        {
            switch (format)
            {
                case "name":
                    return p => Console.WriteLine(p.Name);
                case "age":
                    return p => Console.WriteLine(p.Age);
                case "name age":
                    return p =>
                    {
                        Console.WriteLine($"{p.Name} - {p.Age}");
                    };

                default:
                    return null;
            }
        }

        static Func<Person, bool> GetCondition(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return p => p.Age < age;
                case "older":
                    return p => p.Age >= age;

                default:
                    return null;
            }
        }
    }
}
