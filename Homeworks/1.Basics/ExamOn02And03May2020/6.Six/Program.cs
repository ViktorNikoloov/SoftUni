using System;

namespace _6.Six
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //•	На първи ред получавате количесто мед за зимата: реално число [1.00-1000.00].
            //•	На следващите до получаване на "Winter has come"редове ще получавате:
            //o Име на пчела: string
            //o На следващите 6 реда ще получавате добития от пчелата мед: реално число[-1000.00 - 1000.00]. 
            //o Ако накрая на 6 - те месеца пчелата е изяла повече мед, отколкото е събрала, принтирайте:
            //"{име на пчела} was banished for gluttony"
            double honeyForTheWinter = double.Parse(Console.ReadLine());
            string beeName = Console.ReadLine();

            double totalHoney = 0;
            
            while (beeName != "Winter has come")
            {
                double currHoney = 0;
                for (int i = 0; i < 6; i++)
                {
                    double newHoney = double.Parse(Console.ReadLine());
                    currHoney += newHoney;
                }
               
                if (currHoney < 0)
                {
                    Console.WriteLine($"{beeName} was banished for gluttony");
                }
                totalHoney += currHoney;
                if (totalHoney >= honeyForTheWinter)
                {
                    break;
                }
                beeName = Console.ReadLine();

            }

            if (totalHoney >= honeyForTheWinter)
            {
            Console.WriteLine($"Well done! Honey surplus {totalHoney - honeyForTheWinter:f2}.");
            }
            else
            {
                Console.WriteLine($"Hard Winter! Honey needed {honeyForTheWinter - totalHoney:f2}.");
            }
        }
    }
}
