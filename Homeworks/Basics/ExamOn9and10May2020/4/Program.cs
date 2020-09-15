using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //•	На първи ред получавате брой студенти: цяло число [1-10000].
            //•	На втори ред получавате сезони: цяло число[1 - 1000].
            int students = int.Parse(Console.ReadLine());
            int seasons = int.Parse(Console.ReadLine());
            double totalStudents = students;
            //calculation
            for (int i = 1; i <= seasons; i++)
            {
                totalStudents = Math.Ceiling(totalStudents * 0.9);
                totalStudents = Math.Ceiling(totalStudents * 0.9);
                totalStudents = Math.Ceiling(totalStudents * 0.8);
                if (i % 3 == 0)
                {
                    totalStudents += Math.Ceiling(totalStudents * 0.15);
                    continue;
                }
                totalStudents += Math.Ceiling(totalStudents * 0.05);
                
            }
          
            Console.WriteLine($"Students: {totalStudents}");
        }
    }
}
