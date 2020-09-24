using System;

namespace _5._Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());
            int oBrackets = 0;
            int cBrackets = 0;
            byte consecutiveBrackets = 0;

            for (int i = 0; i < inputLines; i++)
            {
                string input = Console.ReadLine();
                byte currOpening = 0;
                byte currClosing = 0;

                for (int g = 0; g < input.Length; g++)
                {

                    char symbol = input[g];
                    if (symbol == '(')
                    {
                        consecutiveBrackets++;
                        oBrackets++;
                        currOpening++;
                    }
                    else if (symbol == ')')
                    {
                        consecutiveBrackets = 0;
                        cBrackets++;
                        currClosing++;
                    }
                    //if (currOpening > 1)
                    //{
                    //    oBrackets -= currOpening;
                    //    currOpening = 0;
                    //}
                    //if (currClosing > 1)
                    //{
                    //    cBrackets -= currClosing;
                    //    currClosing = 0;
                    //}
                    if (consecutiveBrackets >= 2)
                    {
                        break;
                    }
                }
                if (consecutiveBrackets >= 2)
                {
                    break;
                }
            }
            if (oBrackets - cBrackets != 0)
            {
                Console.WriteLine("UNBALANCED");
                return;
            }
            else if (consecutiveBrackets >= 2)
            {
                Console.WriteLine("UNBALANCED");
            }
            else if (oBrackets == cBrackets)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
