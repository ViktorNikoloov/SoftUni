namespace _02.Conditional_Expression_Resolver
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            var expression = Console.ReadLine()
                .Split()
                .Select(x=> x[0])
                .ToArray();

            Console.WriteLine(ParseExpression(expression, 0));
        }

        private static int ParseExpression(char[] expression, int index)
        {
            if (char.IsDigit(expression[index]))
            {
                return expression[index] - '0';
            }

            if (expression[index] == 't')
            {
                return ParseExpression(expression, index + 2);
            }

            var foundConditions = 0;
            for (int i = index + 2; i < expression.Length; i++)
            {
                var currSymbol = expression[i];
                if (currSymbol == '?')
                {
                    foundConditions++;
                }
                else if (currSymbol == ':')
                {
                    foundConditions--;
                    if (foundConditions < 0)
                    {
                        return ParseExpression(expression, i + 1);
                    }
                }
            }

            throw new InvalidOperationException();
        }
    }
}