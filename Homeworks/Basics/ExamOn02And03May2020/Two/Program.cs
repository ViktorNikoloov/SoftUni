using System;

namespace Two
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //•	На първи ред получавате интелект: цяло число [1-100].
            //•	На втори ред получавате сила: цяло число[1 - 100].
            //•	На трети ред получавате пол: string["female", "male"].
            int intelegent = int.Parse(Console.ReadLine());
            int strength = int.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            string result = "";

            //calculation
            //Queen Bee	>= 80	>= 80	female
            //Repairing Bee   >= 80   Any Any
            //Cleaning Bee    >= 60   Any Any
            //Drone Bee   Any >= 80   male
            //Guard Bee Any >= 60   Any
            //Worker Bee Any Any Any
            if (intelegent >= 80 && strength >= 80 && gender == "female")
            {
                result = "Queen Bee";
            }
            else if (intelegent >= 80)
            {
                result = "Repairing Bee";
            }
            else if (intelegent >= 60)
            {
                result = "Cleaning Bee";
            }
            else if (strength >= 80 && gender == "male")
            {
                result = "Drone Bee";
            }
            else if (strength >= 60)
            {
                result = "Guard Bee";
            }
            else
            {
                result = "Worker Bee";
            }

            Console.WriteLine(result);
        }
    }
}
