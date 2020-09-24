using System;

namespace _4._Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Първи ред – начало на интервала – цяло число в интервала [1...999]
            //•	Втори ред – край на интервала – цяло число в интервала[по - голямо от първото число...1000]
            //•	Трети ред – магическото число – цяло число в интервала[1...10000]
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int r = startNumber ;
            int i = startNumber;
            int counter = 0;
            bool isTrue = false;

            for (; i <= endNumber; i++)
            {
                counter++;
                for (; r <= endNumber; i++)
                {
                    if ((i + r) == magicNumber)
                    {
                        isTrue = true;
                        break;
                    }
                    counter++;
                }

                if (isTrue)
                {
                    break;
                }
                counter++;
            }

            if (isTrue)
            {
                Console.WriteLine($"Combination N:{counter} ({i} + {r} = {i + r})");
            }
            else
            {

            Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
            }

        }
    }
}
