using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> message = Console.ReadLine().Split().ToList();

            List<string> command = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries).ToList();
            while (command[0] != "Reveal")
            {
                

                if (command[0] == "InsertSpace")
                {
                    message.Insert(int.Parse(command[1]), " ");
                }
                else if (command[0] == "Reverse")
                {
                    char[] chars = message[0].ToCharArray();
                    List<string> charList = chars.ToList();
                    Console.WriteLine(string.Join(" ", chars));
                    //string temp = command[1];
                    //for (int i = 0; i < message.Count; i++)
                    //{
                    //    if (message.Contains(command[i]))
                    //    {

                    //    }
                    //    for (int g = 0; g < temp.Length; g++)
                    //    {
                    //        string one = message[i];
                    //        string two = temp[g];

                    //        if (message[i] == temp[g])
                    //        {

                    //        }
                    //    }
                    //}
                    //message.Contains(command[1]);
                    //temp.Reverse();
                    //message.Remove(command[1]);
                    //message.Add(temp);
                    //Console.WriteLine(string.Join(" ", command));
                }


                command = Console.ReadLine().Split().ToList();
            }
        }
    }
}
