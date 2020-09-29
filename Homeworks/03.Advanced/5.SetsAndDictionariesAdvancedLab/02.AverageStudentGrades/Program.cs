using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentRecords = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!studentRecords.ContainsKey(name))
                {
                    studentRecords.Add(name, new List<decimal>(){ grade });
                }
                else
                {
                    studentRecords[name].Add(grade);
                }
            }
            foreach (var grades in studentRecords)
            {
                StringBuilder allGrades = new StringBuilder();
                for (int i = 0; i < grades.Value.Count; i++)
                {
                    allGrades.Append($"{grades.Value[i]:f2} ");
                }
                Console.WriteLine($"{grades.Key} -> {allGrades.ToString().Trim()} (avg: {grades.Value.Average():f2})");
                
            }
        }
    }
}
