using System;

namespace _6._High_Jump
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	На първия ред се прочита желаната от Тихомир Иванов височина в сантиметри
            //На всеки следващ ред до приключване на програмата се прочита височината от скока на Иванов
            int wantedHight = int.Parse(Console.ReadLine());
            int startingHight = wantedHight - 30;
            int jumpCounter = 0;
            int fails = 0;
            bool isFail = false;
            while (startingHight <= wantedHight)
            {
                int currJump = int.Parse(Console.ReadLine());
                jumpCounter++;

                if (currJump > startingHight)
                {
                    startingHight += 5;
                    fails = 0;
                }
                else
                {
                    fails++;
                    
                }
                if (fails >= 3)
                {
                    isFail = true;
                    break;
                }


            }
            if (isFail)
            {
                Console.WriteLine($"Tihomir failed at {startingHight}cm after {jumpCounter} jumps.");
            }
            else
            {
                Console.WriteLine($"Tihomir succeeded, he jumped over {wantedHight}cm after {jumpCounter} jumps.");
            }
        }
    }
}
