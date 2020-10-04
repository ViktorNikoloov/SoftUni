using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] textLines = File.ReadAllLines("../../../text.txt");
            string[] newText = new string[textLines.Length];

            for (int i = 0; i < textLines.Length; i++)
            {
                char[] currLine = textLines[i].ToCharArray();
                int letters = 0;
                int punctuationMarks = 0;

                for (int g = 0; g < currLine.Length; g++)
                {
                    if (char.IsLetter(currLine[g]))
                    {
                        letters++;
                    }
                    if (char.IsPunctuation(currLine[g]))
                    {
                        punctuationMarks++;
                    }
                }

                newText[i] = $"Line {i + 1}: {textLines[i]} ({letters})({punctuationMarks})";
            }

            File.WriteAllLines("../../../Output.txt", newText);
        }
    }
}
