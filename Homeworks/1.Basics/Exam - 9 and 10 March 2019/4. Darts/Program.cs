using System;

namespace _4._Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Името на играча - текст
            string name = Console.ReadLine();
            int leftPoints = 301;
            int winsCounter = 0;
            int losesCounter = 0;

            //След това до получаване на команда "Retire" се четат многократно по два реда:
            //1.Поле – текст("Single", "Double" или "Triple")
            //2.Точки – цяло число в интервала[0… 100]
            string command = Console.ReadLine();
            while (command != "Retire")
            {
                int points = int.Parse(Console.ReadLine());
                
                if (command == "Double")
                {
                    points *= 2;

                }
                else if (command == "Triple")
                {
                    points *= 3;

                }

                if (points > leftPoints)
                {
                    command = Console.ReadLine();
                    losesCounter++;
                    continue;
                }

                winsCounter++;
                leftPoints -= points;
                

                if (leftPoints == 0)
                {
                    Console.WriteLine($"{name} won the leg with {winsCounter} shots.");
                    break;
                }

                
                command = Console.ReadLine();
            }

            if (command == "Retire")
            {
            Console.WriteLine($"{name} retired after {losesCounter} unsuccessful shots.");
            }
        }
    }
}
