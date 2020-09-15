using System;

namespace _04.ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();

            //for (int i = 0; i < strings.Length; i++)
            //{
            //    Console.Write(strings[strings.Length - i - 1] + " ");

            //}
            for (int i = 0; i < strings.Length/2; i++)
            {
                string temp = strings[i];//a
                strings[i] = strings[strings.Length - i - 1];//a
                strings[strings.Length - i - 1] = temp;
            }
            Console.WriteLine(String.Join(" ", strings));
        }
    }
}
