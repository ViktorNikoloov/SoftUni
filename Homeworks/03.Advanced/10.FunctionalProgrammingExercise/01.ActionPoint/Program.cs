using System;

namespace _01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> PrintStringArray = input =>
            {
                Console.WriteLine(string.Join(Environment.NewLine, input));
            };


            PrintStringArray(Console.ReadLine().Split());
        }
    }
}
