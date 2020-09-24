using System;

namespace _10.GreatersOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());
                Console.WriteLine(WhichIsBigger(num1, num2));
            }
            else if (type == "string")
            {
                string num1 = Console.ReadLine();
                string num2 = Console.ReadLine();
                Console.WriteLine(WhichIsBigger(num1, num2));
            }
            else if (type == "char")
            {
                char one = char.Parse(Console.ReadLine());
                char two = char.Parse(Console.ReadLine());
                Console.WriteLine(WhichIsBigger(one, two));
            }
        }

        static int WhichIsBigger(int first, int second)
        {
            int biggerNumber = first.CompareTo(second);
            if (biggerNumber > 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        static string WhichIsBigger(string first, string second)
        {
            int biggerString = first.CompareTo(second);
            if (biggerString > 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        static char WhichIsBigger(char first, char second)
        {
            int biggerChar = first.CompareTo(second);
            if (biggerChar > 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }
    }
}
