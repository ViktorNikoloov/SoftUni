using System;

namespace ProjectsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int numberProjects = int.Parse(Console.ReadLine());
            int hours = numberProjects * 3;
            Console.WriteLine($"The architect {name} will need {hours} hours to complete {numberProjects} project/s.");
        }
    }
}
