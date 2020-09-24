using System;

namespace Graduation2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine(); ;
            double totalGrades = 0;
            int classCounter = 1;
            int repeatYear = 0;

            while (classCounter <= 12)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade < 4)
                {
                    repeatYear++;

                    if (repeatYear == 2)
                    {
                        
                        break;
                    }
                }
                else
                {
                    totalGrades += grade;
                    classCounter += 1;
                }              
            }

            if (repeatYear == 2)
            {
                Console.WriteLine($"{name} has been excluded at {classCounter} grade");
            }
            else
            {
                double average = totalGrades / 12;

                Console.WriteLine($"{name} graduated. Average grade: {average:f2}");
            }
        }
    }
}
