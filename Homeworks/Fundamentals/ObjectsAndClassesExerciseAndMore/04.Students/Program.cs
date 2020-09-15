using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                Student student = new Student(info[0], info[1], double.Parse(info[2]));
                students.Add(student);
            }

            List<Student> orderedStudents = students.OrderByDescending(x => x.Grade).ToList();

            foreach (var student in orderedStudents)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
}
