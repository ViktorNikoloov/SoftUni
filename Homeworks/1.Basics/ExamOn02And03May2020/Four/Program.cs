using System;

namespace Four
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //•	На първи ред получавате начална популация: цяло число [1-1000].
            //•	На втори ред получавате години: цяло число[1 - 100].
            int startPopulation = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int finalPopulation = startPopulation;
            
            for (int i = 1; i <= year; i++)
            {
                finalPopulation += finalPopulation / 10 * 2;
                //Console.WriteLine(finalPopulation);
                if (i % 5 ==0)
                {
                    finalPopulation -= finalPopulation / 50 * 5;
                }

                finalPopulation -= finalPopulation / 20 * 2;
                //Console.WriteLine(finalPopulation);
            }

            Console.WriteLine($"Beehive population: {finalPopulation}");
        }
    }
}
