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
            Dictionary<string, int> wordCounter = FillDictionary(words, text);

            WriteFileOnFile(wordCounter, "../../../actualResult.txt");
            var sortedWordCounter = wordCounter.OrderByDescending(x => x.Value).ToDictionary(k => k.Key, v => v.Value);
            WriteFileOnFile(sortedWordCounter, "../../../expectedResult.txt");
        }

        private static Dictionary<string, int> FillDictionary(List<string> list, string[] text)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            for (int i = 0; i < list.Count; i++)
            {
                for (int g = 0; g < text.Length; g++)
                {
                    string currWord = list[i];
                    string currTextWord = text[g];

                    if (currWord == currTextWord)
                    {
                        if (!dictionary.ContainsKey(currWord))
                        {
                            dictionary.Add(currWord, 0);
                        }

                        dictionary[currWord]++;
                    }
                }

            }

            return dictionary;
        }

        private static List<string> WriteFileOnFile(Dictionary<string, int> dictionary, string path)
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
