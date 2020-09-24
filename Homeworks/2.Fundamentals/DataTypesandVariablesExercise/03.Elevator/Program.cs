using System;

namespace _03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(10 % 5);
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int courses = 0;

            courses = numberOfPeople / capacity;
            if (numberOfPeople % capacity > 0)
            {
                courses++;
            }
            Console.WriteLine(courses);

        }
    }
}
