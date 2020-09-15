using System;

namespace FinalExam07DecemberGroup2Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string[] command = Console.ReadLine().Split();
            while (command[0] != "Finish")
            {
                if (command[0] == "Replace")
                {
                    text = text.Replace(command[1], command[2]);
                    Console.WriteLine(text);
                }
                else if (command[0] == "Cut")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    if (0 <= startIndex && endIndex <= text.Length - 1)
                    {
                        text = text.Remove(startIndex, endIndex - startIndex + 1);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
                else if (command[0] == "Make")
                {
                    if (command[1] == "Upper")
                    {
                        text = text.ToUpper();
                    }
                    else
                    {
                        text = text.ToLower();
                    }
                    Console.WriteLine(text);
                }
                else if (command[0] == "Check")
                {
                    if (text.Contains(command[1]))
                    {
                        Console.WriteLine($"Message contains {command[1]}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {command[1]}");
                    }
                }
                else if (command[0] == "Sum")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    if (0 <= startIndex && endIndex <= text.Length - 1)
                    {
                        string substring = text.Substring(startIndex, endIndex - startIndex + 1);
                        int sum = 0;

                        for (int i = 0; i < substring.Length; i++)
                        {
                            sum += (int)(substring[i]);
                        }
                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }





                command = Console.ReadLine().Split();
            }
        }
    }
}
