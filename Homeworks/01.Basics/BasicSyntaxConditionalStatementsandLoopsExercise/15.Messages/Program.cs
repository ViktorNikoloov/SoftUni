using System;

namespace _15.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string two = "abc";
            string three = "def";
            string four = "ghi";
            string five = "jkl";
            string six = "mno";
            string seven = "pqrs";
            string eight = "tuv";
            string nine = "wxyz";
            string output = "";

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();
                int strLong = input.Length - 1;
               
                if (input[0] == '2')
                {
                    output += two[strLong];
                }
                else if (input[0] == '3')
                {
                    output += three[strLong];
                }
                else if (input[0] == '4')
                {
                    output += four[strLong];
                }
                else if (input[0] == '5')
                {
                    output += five[strLong];
                }
                else if (input[0] == '6')
                {
                    output += six[strLong];
                }
                else if (input[0] == '7')
                {
                    output += seven[strLong];
                }
                else if (input[0] == '8')
                {
                    output += eight[strLong];
                }
                else if (input[0] == '9')
                {
                    output += nine[strLong];
                }
                else if (input[0] == '0')
                {
                    output += " ";
                }

            }
            Console.WriteLine(output);
        }
    }
}
