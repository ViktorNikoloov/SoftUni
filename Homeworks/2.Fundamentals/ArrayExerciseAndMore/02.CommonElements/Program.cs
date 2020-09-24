using System;

namespace _02.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstWords = Console.ReadLine().Split();
            string[] secondWords = Console.ReadLine().Split();
            string output = "";

            for (int i = 0; i < secondWords.Length; i++)
            {
                
                for (int g = 0; g < firstWords.Length; g++)
                {
                    if (firstWords[g] == secondWords[i])
                    {
                        output += secondWords[i] + " ";
                    }
                }
            }
            Console.WriteLine(output);
        }
    }
}
