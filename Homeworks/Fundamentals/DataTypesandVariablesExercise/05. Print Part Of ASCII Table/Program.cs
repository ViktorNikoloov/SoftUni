using System;

namespace _05._Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int startIndex = int.Parse(Console.ReadLine());
            int stopIndex = int.Parse(Console.ReadLine());
            string messages = "";

            for (int i = startIndex; i <=stopIndex; i++)
            {
                char a = (char)i;
                messages += a + " ";
            }
            Console.WriteLine(messages);

            
        }
    }
}
