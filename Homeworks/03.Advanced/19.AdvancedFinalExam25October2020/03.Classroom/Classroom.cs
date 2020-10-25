using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        public int Capacity { get; set; }

        public int Count
            => students.Count;

        public string RegisterStudent(Student student) //Adds an entity to the students if there is an empty seat for the student.
        {
            if (Capacity != Count)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName) //Removes the student by the given names.
        {
            Student student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (student != null)
            {
                students.Remove(student);
                return $"Dismissed student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "Student not found";
            }

        }

        public string GetSubjectInfo(string subject) //Returns all the students with the given subject .
        {
            List<Student> orderedStudents = students.Where(x => x.Subject == subject).ToList();
            if (orderedStudents.Count != 0)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (var student in orderedStudents)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().Trim();
            }
            else
            {
                return $"No students enrolled for the subject";
            }
            
        }

        public int GetStudentsCount()
            => Count;

        public Student GetStudent(string firstName, string lastName)
        => students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
    }
}
