using System;

namespace GraduationWhileLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double totalGrades = 0;
            int classCounter = 0;

            while (classCounter < 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4)
                {
                    continue;
                }
                else
                {
                    classCounter += 1;
                    totalGrades += grade;
                }
            }

            double average = totalGrades / 12;

            Console.WriteLine($"{name} graduated. Average grade: {average:f2}");
        }
    }
}
