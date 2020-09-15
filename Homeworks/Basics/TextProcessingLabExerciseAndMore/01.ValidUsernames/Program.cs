using System;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0; i < words.Length; i++)
            {
                string currWord = words[i];
                if (3 <= words[i].Length && words[i].Length <= 16)
                {
                    bool isCorrect = true;
                    for (int g = 0; g < currWord.Length; g++)
                    {
                        if (!(char.IsLetterOrDigit(currWord[g]) || currWord[g] == '-' || currWord[g] == '_'))
                        {
                            isCorrect = false;
                        }
                    }

                    if (isCorrect)
                    {
                        Console.WriteLine(currWord);
                    }
                }
            }

        }
    }
}
