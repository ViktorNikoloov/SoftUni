using System;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	На първия ред – броя на студентите явили се на изпит – цяло число в интервала[1...1000]
            //•	За всеки един студент на отделен ред – оценката от изпита – реално число в интервала[2.00...6.00]

            double students = double.Parse(Console.ReadLine()) * 1.0;

            double allGrades = 0;
            int overFive = 0; //over 5.00
            int betweenFourAndFive = 0; // 4.00 - 4.99
            int betweenThreeAndFour = 0; // 3.00 - 3.99
            int belowThree = 0; // below 3.00

            for (double i = 0; i < students; i++)
            {
                double gradeFromExam = double.Parse(Console.ReadLine());

                if (gradeFromExam >= 5.00)
                {
                    allGrades += gradeFromExam;
                    overFive += 1;
                }
                else if (4.00 <= gradeFromExam && gradeFromExam <= 4.99)
                {
                    allGrades += gradeFromExam;
                    betweenFourAndFive += 1;
                }
                else if (3.00 <= gradeFromExam && gradeFromExam <= 3.99)
                {
                    allGrades += gradeFromExam;
                    betweenThreeAndFour += 1;
                }
                else
                {
                    allGrades += gradeFromExam;
                    belowThree += 1;
                }
            }

            Console.WriteLine($"Top students: {1.0 * overFive / students * 100:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {1.0 * betweenFourAndFive / students * 100:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {1.0 * betweenThreeAndFour / students * 100:f2}%");
            Console.WriteLine($"Fail: {1.0 * belowThree / students * 100:f2}%");
            Console.WriteLine($"Average: {allGrades / students:f2}");
        }
    }
}
