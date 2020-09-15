using System;

namespace _4._TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int jury = int.Parse(Console.ReadLine());
            double finalAverage = 0;
            int counter = 0;
            string presentation = Console.ReadLine();
            while (presentation != "Finish")
            {
                double average = 0;

                for (int i = 0; i < jury; i++)
                {
                    double mark = double.Parse(Console.ReadLine());
                    average += mark;
                    counter++;
                    finalAverage += mark;
                }
                Console.WriteLine($"{presentation} - {average / jury:f2}.");
                presentation = Console.ReadLine();

            }

            Console.WriteLine($"Student's final assessment is {finalAverage / counter:f2}.");

        }
    }
}
