using System;

namespace _4._Decrypting_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int key = int.Parse(Console.ReadLine());
            int input = int.Parse(Console.ReadLine());
            string masseges = "";

            for (int i = 0; i < input; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                masseges += (char)(symbol + key);

            }
            Console.WriteLine(masseges);
        }
    }
}
