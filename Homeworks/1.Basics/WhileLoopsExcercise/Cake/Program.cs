using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int wide = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int cakeSize= wide * length;
            int pieces = 0;
            bool isCakeWhole = false;

            while (cakeSize >= pieces)
            {
                string cake = Console.ReadLine();
                if (cake == "STOP")
                {
                    isCakeWhole = true;
                    break;
                }
                pieces += int.Parse(cake);

            }

            if (isCakeWhole)
            {
                Console.WriteLine($"{cakeSize - pieces} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {pieces - cakeSize} pieces more.");
            }
        }
    }
}
