using System;

namespace _5.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            char[] chars = username.ToCharArray();
            Array.Reverse(chars);
            string reversedUsername = new String(chars);
            string password = Console.ReadLine();
            bool isCorrect = true;
            int counter = 0;

            while (password != reversedUsername)
            {
                counter++;

                if (counter == 4)
                {
                    isCorrect = false;
                    break;
                }
                Console.WriteLine("Incorrect password. Try again. ");
                password = Console.ReadLine();
            }

            if (isCorrect)
            {
                Console.WriteLine($"User {username} logged in. ");
            }
            else
            {
                Console.WriteLine($"User {username} blocked! ");
            }

        }
    }
}
