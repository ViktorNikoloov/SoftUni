using System;

namespace ExamPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //•	На първи ред получавате задача: цяло число [1, 4].
            //•	На втори ред получавате точки: цяло число[0 - 100].
            //•	На трети ред получавате курс: string["Basics", "Fundamentals", "Advanced"].
            int task = int.Parse(Console.ReadLine());
            int points = int.Parse(Console.ReadLine());
            string course = Console.ReadLine();
            double mark = 0;

            //calculation
            switch (course)
            {
                case "Basics":
                    switch (task)
                    {
                        case 1:
                            mark = points * 0.08;
                            break;

                        case 2:
                        case 3:
                            mark = points * 0.09;
                            break;

                        case 4:
                            mark = points * 0.10;
                            break;
                    }
                    break;

                case "Fundamentals":
                    switch (task)
                    {
                        case 1:
                        case 2:
                            mark = points * 0.11;
                            break;
                        case 3:
                            mark = points * 0.12;
                            break;

                        case 4:
                            mark = points * 0.13;
                            break;
                    }
                    break;

                case "Advanced":
                    switch (task)
                    {
                        case 1:
                        case 2:
                            mark = points * 0.14;
                            break;
                        case 3:
                            mark = points * 0.15;
                            break;

                        case 4:
                            mark = points * 0.16;
                            break;
                    }
                    break;
            }

            if (course == "Advanced")
            {
                mark *= 1.2;
            }
            if (task == 1 && course == "Basics")
            {
                mark *= 0.8;
            }

            //output
            Console.WriteLine($"Total points: {mark:f2}");
        }
    }
}
