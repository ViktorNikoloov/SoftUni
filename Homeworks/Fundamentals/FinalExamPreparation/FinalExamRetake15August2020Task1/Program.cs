using System;
using System.Linq;

namespace FinalExamRetake15August2020Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string[] command = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

            while (!command.Contains("Decode"))
            {
               
                if (command.Contains("Move")) //•	Move {number of letters}
                {
                    int number = int.Parse(command[1]);

                    string substring = message.Substring(0, number);
                    message = message.Remove(0, number);
                    message = message += substring;

                }
                else if (command.Contains("Insert")) //•	Insert {index} {value}
                {
                    int index = int.Parse(command[1]);
                    string value = command[2];

                    message = message.Insert(index, value);
                }
                else if (command.Contains("ChangeAll")) //•	ChangeAll {substring} {replacement} 
                {
                    string substring = command[1];
                    string replacement = command[2];

                    message = message.Replace(substring, replacement);

                }

                command = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
