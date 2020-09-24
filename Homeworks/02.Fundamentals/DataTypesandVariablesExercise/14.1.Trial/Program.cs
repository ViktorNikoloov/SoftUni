using System;

namespace FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());

            for (int line = 0; line < linesCount; line++)
            {
                string number = Console.ReadLine();
                string leftNum = "";
                string rightNum = "";
                long biggerNum = 0;
                long numberSum = 0;
                int counter = -1;

                for (int i = 0; i < number.Length; i++)
                {
                    counter++;
                    char symbol = number[i];

                    if (symbol == ' ')
                    {
                        break;
                    }

                    leftNum += symbol;
                }

                for (int i = counter + 1; i < number.Length; i++)
                {
                    char symbol = number[i];
                    rightNum += symbol;
                }

                biggerNum = Math.Max(Convert.ToInt64(leftNum), Convert.ToInt64(rightNum));

                while (Math.Abs(biggerNum) > 0)
                {
                    numberSum += Math.Abs(biggerNum) % 10;
                    biggerNum = Math.Abs(biggerNum) / 10;
                }

                Console.WriteLine(numberSum);
            }
        }
    }
}