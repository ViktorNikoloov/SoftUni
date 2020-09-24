using System;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //•	До получаване на "Midnight" ще получавате:
            //o Име на студент: string
            //o На следващите 6 реда ще получавате точки на задача: цяло число[-100, 100]. 
            //o Ако получите отрицателни точки, санкция за преписване, принтирайте:
            //"{име на студент} was cheating!"
            //и преустановете четенето на точки за текущия студент.
            string name = Console.ReadLine();
            while (name != "Midnight")
            {
                bool isCheating = false;
                double grade = 0;
                double totalPoints = 0;

                for (int i = 0; i < 6; i++)
                {
                    int points = int.Parse(Console.ReadLine());
                    if (points < 0)
                    {
                        Console.WriteLine($"{name} was cheating!");
                        isCheating = true;
                        break;
                    }
                    totalPoints += points;
                }
                if (isCheating)
                {
                    name = Console.ReadLine();
                    continue;
                }
                totalPoints = Math.Floor((totalPoints / 600.0) * 100);
                grade = totalPoints * 0.06;

                if (grade < 5)
                {
                    if (grade < 3)
                    {
                        grade = 2;
                    }
                    Console.WriteLine($"{name} - {grade:f2}");
                }
                else
                {
                    Console.WriteLine("===================");
                    Console.WriteLine("|   CERTIFICATE   |");
                    Console.WriteLine($"|    {grade:f2}/6.00    |");
                    Console.WriteLine("===================");
                    Console.WriteLine($"Issued to {name}");
                }

                name = Console.ReadLine();
            }

        }
    }
}
