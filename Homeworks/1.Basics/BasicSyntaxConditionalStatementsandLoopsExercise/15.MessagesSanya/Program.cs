using System;

namespace _15.MessagesSanya
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
                char index = input[0];

                switch (index)
                {
                    case '2':
                        output += two[input.Length - 1];
                        break;

                    case '3':
                        output += three[input.Length - 1];
                        break;

                    case '4':
                        output += four[input.Length - 1];
                        break;

                    case '5':
                        output += five[input.Length - 1];
                        break;

                    case '6':
                        output += six[input.Length - 1];
                        break;

                    case '7':
                        output += seven[input.Length - 1];
                        break;

                    case '8':
                        output += eight[input.Length - 1];
                        break;

                    case '9':
                        output += nine[input.Length - 1];
                        break;

                    default:
                        output += " ";
                        break;
                }
            }
            Console.WriteLine(output);
        }
    }
}
