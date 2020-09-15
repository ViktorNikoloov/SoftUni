using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Students> students = new List<Students>();

            while (command != "end")
            {
                bool isRepeat = false;
                string[] input = command.Split().ToArray();

                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[2]);
                string homeTown = input[3];

                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].FirstName == firstName && students[i].LastName == lastName)
                    {
                        students[i].Age = age;
                        students[i].HomeTown = homeTown;
                        isRepeat = true;
                    }
                    
                }

                if (isRepeat)
                {
                    command = Console.ReadLine();
                }
                else
                {
                    Students newStudent = new Students();

                    newStudent.FirstName = firstName;
                    newStudent.LastName = lastName;
                    newStudent.Age = age;
                    newStudent.HomeTown = homeTown;


                    students.Add(newStudent);

                    command = Console.ReadLine();
                }
                

            }

            string cityName = Console.ReadLine();

            foreach (var item in students)
            {
                if (item.HomeTown == cityName)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName} is {item.Age} years old.");
                }
            }
        }
    }

    class Students
    {
        //first name, last name, age and hometown. 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}
