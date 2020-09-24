using System;

namespace Five
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //•	На първи ред получавате брой пчели: цяло число [100-10000].
            //•	На втори ред получавате здраве: цяло число[1 - 10000].
            //•	На трети ред получавате атака: цяло число[1 - 10000].
            int bees = int.Parse(Console.ReadLine());
            int health = int.Parse(Console.ReadLine());
            int atack = int.Parse(Console.ReadLine());
            bool isBeesFail = false;
            bool isBearFail = false;

            //calculation
            //Всяка пчела има 1 здраве и нанася 5 щета 
            //Първо атакува мечката, а след това пчелите заедно контраатакуват.
            //Ако броят пчели падне под 100, мечката печели и открадва меда
            //Ако здравето на мечката падне до 0
            while (true)
            {
                if (health <= 0)
                {
                    isBearFail = true; ;
                    break;
                }
                if (bees < 100)
                {
                    isBeesFail = true;
                    break;
                }
                bees -= atack;
                health -= bees * 5;
            }

            if (bees < 0)
            {
                bees = 0;
            }
            if (isBeesFail)
            {
                Console.WriteLine($"The bear stole the honey! Bees left {bees}.");
            }
            if (isBearFail)
            {
                Console.WriteLine($"Beehive won! Bees left {bees}.");
            }
        }
    }
}
