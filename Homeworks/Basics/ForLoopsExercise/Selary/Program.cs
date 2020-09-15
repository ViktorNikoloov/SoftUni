using System;

namespace Selary
{
    class Program
    {
        static void Main(string[] args)
        {
            int tabNumbers = int.Parse(Console.ReadLine());
            int selary = int.Parse(Console.ReadLine());
            int selaryLeft = selary;
            bool isValid = true;

            for (int i = 0; i < tabNumbers; i++)
            {
                string webSites = Console.ReadLine();

                switch (webSites)
                {
                    case "Facebook":
                        selaryLeft -= 150;
                        break;
                    case "Instagram":
                        selaryLeft -= 100;
                        break;
                    case "Reddit":
                        selaryLeft -= 50;
                        break;
                }

                if (selaryLeft == 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }

            }
            if (selaryLeft > 0)
            {
                Console.WriteLine(selaryLeft);
            }
        }
    }
}
