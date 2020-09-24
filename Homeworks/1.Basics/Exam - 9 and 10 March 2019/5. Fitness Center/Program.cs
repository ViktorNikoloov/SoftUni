using System;

namespace _5._Fitness_Center
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	На първия ред – броят на посетителите във фитнеса – цяло число в интервала [1...1000]
            //•	За всеки един посетител на отделен ред – дейността във фитнеса – текст("Back", "Chest", "Legs", "Abs", "Protein shake" или "Protein bar")
            int visitors = int.Parse(Console.ReadLine());
            int back = 0;
            int chest = 0;
            int legs = 0;
            int abs = 0;
            int proteinShake = 0;
            int proteinBar= 0;

            for (int i = 0; i < visitors; i++)
            {
                string activity = Console.ReadLine();

                if (activity == "Back")
                {
                    back++;
                }
                if (activity == "Chest")
                {
                    chest++;
                }
                if (activity == "Legs")
                {
                    legs++;
                }
                if (activity == "Abs")
                {
                    abs++;
                }
                if (activity == "Protein shake")
                {
                    proteinShake++;
                    
                }
                if (activity == "Protein bar")
                {
                    proteinBar++;
                }

            }
            Console.WriteLine($"{back} - back");
            Console.WriteLine($"{chest} - chest");
            Console.WriteLine($"{legs} - legs");
            Console.WriteLine($"{abs} - abs");
            Console.WriteLine($"{proteinShake} - protein shake");
            Console.WriteLine($"{proteinBar} - protein bar");
            Console.WriteLine($"{(double)(back + chest + legs + abs) / visitors * 100:f2}% - work out");
            Console.WriteLine($"{(double)(proteinBar + proteinShake) / visitors * 100:f2}% - protein");

        }
    }
}
