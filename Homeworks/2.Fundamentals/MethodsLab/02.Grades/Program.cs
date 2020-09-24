using System;

namespace _02.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateGrades(double.Parse(Console.ReadLine()));
        }

        static void CalculateGrades(double grade)
        {
            
            if (2.00 <= grade && grade <= 2.99)
            {
                Console.WriteLine("Fail");
            }
            else if (3.00 <= grade && grade <= 3.49)
            {
                Console.WriteLine("Poor");
            }
            else if (3.50 <= grade && grade <= 4.49)
            {
                Console.WriteLine("Good");
            }
            else if (4.50 <= grade && grade <= 5.49)
            {
                Console.WriteLine("Very good");
            }
            else if (5.50 <= grade && grade <= 6.00)
            {
                Console.WriteLine("Excellent");
            }

        }
    }
}
