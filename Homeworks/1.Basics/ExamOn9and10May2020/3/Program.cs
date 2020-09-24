using System;

namespace ExamCategories
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //•	На първи ред получавате сложност: цяло число [1, 100].
            //•	На втори ред получавате завъртяност: цяло число[1, 100].
            //•	На трети ред получавате брой страници: цяло число[1, 10].
            int complexity = int.Parse(Console.ReadLine());
            int rotation = int.Parse(Console.ReadLine());
            int pages = int.Parse(Console.ReadLine());
            string examType = "";

            if (complexity >= 80 && rotation >= 80 && pages >= 8)
            {
                examType = "Legacy";
            }
            else if (complexity >= 80 && rotation <= 10)
            {
                examType = "Master";
            }
            else if (complexity <= 10)
            {
                examType = "Elementary";
            }
            else if (complexity <= 30 && pages <= 1)
            {
                examType = "Easy";
            }
            else if (rotation >= 50 && pages >= 2)
            {
                examType = "Hard";
            }
            else
            {
                examType = "Regular";
            }

            Console.WriteLine(examType);
        }
    }
}
