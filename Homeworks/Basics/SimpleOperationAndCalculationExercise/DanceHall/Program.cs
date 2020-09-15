using System;

namespace DanceHall
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            // 1.L – дължина на залата в метри – реално число в интервала[10.00 … 100.00]
            // 2.W – ширина на залата в метри – реално число в интервала[10.00 … 100.00]
            // 3.А – страна на гардероба в метри – реално число в интервала[2.00… 20.00]

            double lendght = double.Parse(Console.ReadLine());
            double wedght = double.Parse(Console.ReadLine());
            double sideWardrobe = double.Parse(Console.ReadLine());

            // Calculation
            //Правоъгълна и има размери: L - дължина и W -ширина(в метри).
            //В залата има квадратен гардероб със страна -A и правоъгълна скамейка 
            //с площ 10 пъти по-малка от площта на залата.  Мястото, което заема един 
            //танцьор е 40 см² и допълнително за свободно движение му трябват още  7000см². 

            double danceHallArea = (lendght * 100) * (wedght * 100);
            double bench = danceHallArea / 10;
            double wardrobeArea = (sideWardrobe * 100) * (sideWardrobe* 100);
            double freeSpace = danceHallArea - bench - wardrobeArea;
            double dancerFreeSpace = (7000 + 40);

            // Output
            // Да се отпечата на конзолата едно цяло число – броя танцьори, 
            // които могат да се поберат в свободното пространство на залата, 
            // закръглени до най-близкото цяло число надолу.

            Console.WriteLine(Math.Floor(freeSpace / dancerFreeSpace));
            

        }
    }
}
