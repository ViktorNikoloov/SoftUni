using System;

namespace _02.GenericBoxOfInteger
{
    public class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> number = new Box<int>(input);

                Console.WriteLine(number.ToString());

            }
        }
    }
}
