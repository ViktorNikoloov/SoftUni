using System;

namespace _6._High_Jump
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	На първия ред се прочита желаната от Тихомир Иванов височина в сантиметри
            //На всеки следващ ред до приключване на програмата се прочита височината от скока на Иванов
            int hight = int.Parse(Console.ReadLine());
            int startJump = hight - 30;
            int jumpCounter = 0;
            int fails = 0;
            while (true)
            {
                int currJump = int.Parse(Console.ReadLine());
                jumpCounter++;
                if (startJump >= hight)
                {
                    Console.WriteLine($"Tihomir succeeded, he jumped over {hight}cm after {jumpCounter} jumps.");
                    break;
                }
                if (currJump > startJump)
                {
                    startJump += 5;
                    fails = 0;
                }
                else
                {
                    fails++;
                }
                if (fails >= 3)
                {
                    Console.WriteLine($"Tihomir failed at {startJump}cm after {jumpCounter} jumps.");
                    break;
                }


            }
        }
    }
}
