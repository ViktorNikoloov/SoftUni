using System;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string reversedPassword = string.Empty;
            int counter = 0;
            bool isBlock = false;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                char symbol = username[i];
                reversedPassword += symbol;
            }
            string password = Console.ReadLine();

            while (password != reversedPassword)
            {
                counter++;
                if (counter >= 4)
                {
                    isBlock = true;
                    break;
                }
                Console.WriteLine("Incorrect password. Try again.");
                
                password = Console.ReadLine();
            }
            if (isBlock)
            {
                Console.WriteLine($"User {username} blocked!");
            }
            else
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
