using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double grades = 0;
            

            for (int i = 0; i < 12;i++)
            {
                double currgrades = double.Parse(Console.ReadLine());
                grades += currgrades;

                if (currgrades < 4)
                {
                    grades -= currgrades;
                    i -= 1;
                }
            }
            double middleGrade = grades / 12;

            Console.WriteLine($"{name} graduated. Average grade: {middleGrade:f2}");
        }
    }
}
