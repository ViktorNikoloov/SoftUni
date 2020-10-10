using System;
using System.Collections.Generic;
using System.Net;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family members = new Family();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
                members.AddMember(person);
            }

            var  oldPeople= members.GetMembersByAge(30);

            foreach (var person in oldPeople)
            {
                Console.WriteLine($"{person.Name} - {person .Age}");
            }
        }
    }
}
