using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "end")
            {
                string course = input[0];
                string name = input[1];
                //List<string> students = new List<string>();

                if (!courses.ContainsKey(course))
                {
                    //students.Add(name);
                    courses.Add(course, new List<string>());
                    courses[course].Add(name);
                }
                else
                {
                    courses[course].Add(name);
                }

                input = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            }

            //var sortedCourses = courses.OrderByDescending(x => x.Value.Count);


            foreach (var course in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var list in course.Value.OrderBy(x => x))
                {
                    Console.WriteLine("-- " + list);
                }


            }

        }

    }
}
