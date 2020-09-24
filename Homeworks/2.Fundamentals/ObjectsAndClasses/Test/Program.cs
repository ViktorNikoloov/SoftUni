using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many students in SoftUNi");
            int n = int.Parse(Console.ReadLine());
            List<Students> students = new List<Students>();

            for (int i = 0; i < n; i++)
            {
                students.Add(ReadStudet());
            }

            for (int i = 0; i < n; i++)
            {
                WriteStudents(students[i]);
            }
        }

        static Students ReadStudet()
        {
            Students student = new Students();
            Console.WriteLine("What is your First Name:");
            student.firstName = Console.ReadLine();
            Console.WriteLine("What is your Last Name:");
            student.lastName = Console.ReadLine();
            Console.WriteLine("What is your age:");
            student.age = int.Parse(Console.ReadLine());
            Console.WriteLine("What is your emeil:");
            student.emeil = Console.ReadLine();
            Console.WriteLine("Where do you live?");
            student.city = Console.ReadLine();
            return student;
        }

        public static void WriteStudents(Students student)
        {
            Console.WriteLine($"{student.firstName} {student.lastName} at age{student.age} live in {student.city} town. With emeil:{student.emeil}.");
        }
    }

    public class Students
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string emeil { get; set; }
        public string city { get; set; }

       

        

        //public Students(string firstName, string lastName, int Age)
        //{

        //}

        //public Students(string firstName, int age)
        //{

        //}

        //public Students(string lastName, string emeil, string city)
        //{

        //}
    }
}
