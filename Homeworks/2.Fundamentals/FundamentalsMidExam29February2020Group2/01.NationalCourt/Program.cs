using System;
using System.Threading;

namespace _01.NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());

            int questionsAnswered = first + second + third;
            int hours = 0;
            int count = 0;

            while (people > 0)
            {
                if (count == 3)
                {
                   // people += questionsAnswered;
                    hours++;
                    count = 0;

                }
                else
                {
                    people -= questionsAnswered;
                    count++;
                    hours++;
                }
                
                
               
                    
                
                

                
            }
            
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
