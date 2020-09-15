using System;

namespace NumbersDividedBy3WithoutReminder
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 3; i <= 100; i += 3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
