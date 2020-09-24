using System;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string password = Console.ReadLine();

            string currpass = Console.ReadLine();
            while (currpass != password)
            {
                currpass = Console.ReadLine();
            }

            Console.WriteLine($"Welcome {userName}!");
        }
    }
}
