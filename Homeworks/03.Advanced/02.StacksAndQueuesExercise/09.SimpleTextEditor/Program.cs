using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            Stack<string> oldTexts = new Stack<string>();
            oldTexts.Push(text.ToString());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                int command = int.Parse(input[0]);

                if (command == 1) //appends
                {
                    string newText = input[1];
                    text.Append(newText);
                    oldTexts.Push(text.ToString());
                }
                else if (command == 2) //erases 
                {
                    int count = int.Parse(input[1]);
                    text.Remove(text.Length - count, count);
                    oldTexts.Push(text.ToString());
                }
                else if (command == 3) //returns
                {
                    int index = int.Parse(input[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (command == 4) // 1 2 3 4
                {
                    oldTexts.Pop();
                    text = new StringBuilder();
                    text.Append(oldTexts.Peek());
                }
            }
        }
    }
}
