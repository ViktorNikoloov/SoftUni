using System;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int badGrades = int.Parse(Console.ReadLine());
            int counterBadGrades = 0;
            int allGrades = 0;
            int allExercise = 0;
            string lastExercise = "";
            bool endOfExam = false;



            while (true)
            {
                string exerciseName = Console.ReadLine();
                if (exerciseName == "Enough")
                {
                    endOfExam = true;
                    break;
                }

                int currentGrade = int.Parse(Console.ReadLine());
                allGrades += currentGrade;
                allExercise++;
                lastExercise = exerciseName;

                if (currentGrade <= 4)
                {
                    counterBadGrades++;
                    if (counterBadGrades >= badGrades)
                    {
                        break;
                    }
                }
            }

            if (endOfExam)
            {

                Console.WriteLine($"Average score: {1.0 * allGrades / allExercise:f2}");
                Console.WriteLine($"Number of problems: {allExercise}");
                Console.WriteLine($"Last problem: {lastExercise}");
            }
            else
            {
                Console.WriteLine($"You need a break, {counterBadGrades} poor grades.");

            }
        }
    }
}
