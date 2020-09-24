using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Student> students = new Dictionary<string, Student>();
            Dictionary<string, int> submissionsCount = new Dictionary<string, int>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] information = input.Split("-", StringSplitOptions.RemoveEmptyEntries); // "{username}-{language}-{points}" 

                string username = information[0];

                if (information.Length <= 2) //"{username}-banned". 
                {
                    if (students.ContainsKey(username))
                    {
                        students.Remove(username);
                        continue;
                    }

                }

                string language = information[1];
                int points = int.Parse(information[2]);

                if (!students.ContainsKey(username))
                {
                    Student student = new Student(language, points);
                    students.Add(username, student);
                }
                else
                {
                    if (students[username].Points < points)
                    {
                        students[username].Points = points;
                    }
                }

                if (!submissionsCount.ContainsKey(language))
                {
                    submissionsCount.Add(language, 1);
                }
                else
                {
                    submissionsCount[language]++;
                }

            }

            Console.WriteLine("Results:");
            foreach (var student in students.OrderByDescending(x => x.Value.Points).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{student.Key} | {student.Value.Points}");
            }

            Console.WriteLine("Submissions:");
            foreach (var item in submissionsCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

        }
    }

    class Student
    {
        public string Username { get; set; }
        public string Lenguage { get; set; }
        public int Points { get; set; }

        public Student(string language, int points)
        {
            this.Lenguage = language;
            this.Points = points;
        }
    }

}
