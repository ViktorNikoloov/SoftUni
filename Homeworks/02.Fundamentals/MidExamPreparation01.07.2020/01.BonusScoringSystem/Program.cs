using System;
using System.Runtime.InteropServices;

namespace _01.BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int AdditionalBonus = int.Parse(Console.ReadLine());
            double maxBonus = 0;
            int StudentAttended = 0;
           
            for (int i = 0; i < studentsCount; i++)
            {
                int studentsAttendances = int.Parse(Console.ReadLine());
                double currBonus = (double)studentsAttendances / lecturesCount * (5 + AdditionalBonus);

                if (maxBonus<currBonus)
                {
                    maxBonus = currBonus;
                    StudentAttended = studentsAttendances;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {StudentAttended} lectures.");
        }
    }
}
