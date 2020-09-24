using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalExam07DecemberGroup1Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            string[] command = Console.ReadLine().Split();
            while (command[0] != "Complete")
            {
                if (command.Contains("Upper"))
                {
                    email = email.ToUpper();
                    Console.WriteLine(email);
                }
                else if (command.Contains("Lower"))
                {
                    email = email.ToLower();
                    Console.WriteLine(email);
                }
                else if (command[0] == "GetDomain")
                {
                    int minus = int.Parse(command[1]);
                    Console.WriteLine(email.Substring(email.Length - minus));
                }
                else if (command[0] == "GetUsername")
                {
                    int index = email.IndexOf("@");

                    if (index != -1)
                    {
                        Console.WriteLine(email.Substring(0, index));
                    }
                    else
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                }
                else if (command[0] == "Replace")
                {
                    email = email.Replace(char.Parse(command[1]), '-');
                    Console.WriteLine(email);
                }
                else if (command[0] == "Encrypt")
                {
                    List<int> charToNum = new List<int>();

                    for (int i = 0; i < email.Length; i++)
                    {
                        int curr = email[i];
                        charToNum.Add(curr);
                    }

                    Console.WriteLine(string.Join(" ", charToNum));

                }

                command = Console.ReadLine().Split();

            }
        }
    }
}
