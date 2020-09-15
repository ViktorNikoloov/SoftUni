using System;

namespace ExcellentGrade
{
    class Program
    {
        static void Main(string[] args)
        {
            // Conditionla
            // Kонзолна програма, която чете оценка (десетично число), въведена от потребителя и отпечатва "Excellent!", ако оценката е 5.50 или по-висока.

            // input
            double grade = double.Parse(Console.ReadLine());

            // Calculation
            if (grade >= 5.50)
            {
                Console.WriteLine("Excellent!");

            }
        }
    }
}
