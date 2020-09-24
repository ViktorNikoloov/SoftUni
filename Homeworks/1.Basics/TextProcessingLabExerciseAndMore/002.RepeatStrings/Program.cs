using System;

namespace _002.RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string output = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                string currWord = input[i];

                for (int g = 0; g < currWord.Length; g++)
                {
                    output += currWord;
                }
            }

            //for (int i = 0; i < input.Length; i++)
            //{


            //    for (int g = 0; g < input[i].Length; g++)
            //    {
            //        Console.Write(input[i]);

            //    }
            //}

            Console.WriteLine(output);
        }
    }
}
