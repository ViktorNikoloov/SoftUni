using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = File.ReadAllLines("../../../words.txt").ToArray().ToList();
            string[] text = File.ReadAllText("../../../text.txt").ToLower().Split(new char[] { '-', '.', ',', ' ', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Dictionary<string, int> wordCounter = new Dictionary<string, int>();

            for (int i = 0; i < words.Count; i++)
            {
                for (int g = 0; g < text.Length; g++)
                {
                    string currWord = words[i];
                    string currTextWord = text[g];

                    if (currWord == currTextWord)
                    {
                        if (!wordCounter.ContainsKey(currWord))
                        {
                            wordCounter.Add(currWord, 0);
                        }

                        wordCounter[currWord]++;
                    }
                }

            }
            Print(wordCounter, "../../../actualResult.txt");

            var sortedWordCounter = wordCounter.OrderByDescending(x => x.Value).ToDictionary(k => k.Key, v => v.Value);
            Print(sortedWordCounter, "../../../expectedResult.txt");
        }

        private static List<string> Print(Dictionary<string, int> dictionary, string path)
        {
            List<string> output = new List<string>();

            foreach (var word in dictionary)
            {
                output.Add($"{word.Key} - {word.Value}");
            }

            File.AppendAllLines(path, output);
            return output;
        }
    }
}
