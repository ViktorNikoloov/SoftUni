using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsToFind = new Dictionary<string, int>();

            using (StreamReader wordsReader = new StreamReader("../../../words.txt"))
            {
                while (!wordsReader.EndOfStream)
                {
                    string[] words = wordsReader.ReadLine().ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    foreach (var line in words)
                    {
                        if (!wordsToFind.ContainsKey(line))
                        {
                            wordsToFind.Add(line, 0);
                        }

                    }
                }

            }

            using (StreamReader textReader = new StreamReader("../../../text.txt"))
            {
                while (!textReader.EndOfStream)
                {
                    string[] lines = textReader.ReadLine().ToLower().Split(new char[] { '-', ',', '.', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in lines)
                    {
                        if (wordsToFind.ContainsKey(word))
                        {
                            wordsToFind[word]++;
                        }
                    }

                }
            }
            var sortedWords = wordsToFind.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

            using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
            {
                foreach (var word in sortedWords)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }

        }
    }
}
