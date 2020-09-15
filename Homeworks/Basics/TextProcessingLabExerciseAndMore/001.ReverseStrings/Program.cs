using System;

namespace _001.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            
            while ((input = Console.ReadLine()) != "end")
            {
                string output = string.Empty;

                for (int i = input.Length - 1; i >= 0; i--)
                {
                    output += input[i];
                }
                Console.WriteLine($"{input} = {output}");
            }

            
        }
    }
}
