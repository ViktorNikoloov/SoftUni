using System;

namespace _01.SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            int count = 0;
            int hours = 0;

            int answers = first + second + third;

            while (students > 0)
            {
                if (count == 3)
                {
                    hours++;
                    count = 0;
                }
                else
                {
                    count++;
                    hours++;
                    students -= answers;
                }
                
            }

            Console.WriteLine($"Time needed: {hours}h.");

        }
    }
}
