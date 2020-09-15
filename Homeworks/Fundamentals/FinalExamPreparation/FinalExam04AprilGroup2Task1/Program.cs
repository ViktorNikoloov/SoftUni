using System;
using System.Linq;

namespace FinalExam04AprilGroup2Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string[] command = Console.ReadLine().Split();
            while (!(command.Contains("Done")))
            {
                if (command.Contains("TakeOdd"))
                {
                    string newPass = "";

                    for (int i = 0; i < text.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            newPass += (text[i]);
                        }
                    }
                    text = newPass;

                    Console.WriteLine(text);
                }
                if (command.Contains("Cut"))
                {
                    int index = int.Parse(command[1]);
                    int length = int.Parse(command[2]);

                    text = text.Remove(index, length);

                    Console.WriteLine(text);
                }
                if (command.Contains("Substitute"))
                {
                    string substring = command[1];
                    string substitute = command[2];

                    if (text.Contains(substring))
                    {
                        text = text.Replace(substring, substitute);

                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

                command = Console.ReadLine().Split();

            }

            Console.WriteLine($"Your password is: {text}");
        }
    }
}
