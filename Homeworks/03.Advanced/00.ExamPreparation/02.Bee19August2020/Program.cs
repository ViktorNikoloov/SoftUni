using System;

namespace _02.Bee19August2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            int beeRow = 0;
            int beeCol = 0;
            int flowers = 0;

            char[,] beehive = FillSquare(length, ref beeRow, ref beeCol);

            string command = Console.ReadLine();
            while (command != "End")
            {
                beehive[beeRow, beeCol] = '.';

                if (command == "up")
                {
                    beeRow--;
                }
                else if (command == "down")
                {
                    beeRow++;
                }
                else if (command == "right")
                {
                    beeCol++;
                }
                else if (command == "left")
                {
                    beeCol--;
                }

                if (!(beeRow >= 0 && beeRow < beehive.GetLength(0)
                && beeCol >= 0 && beeCol < beehive.GetLength(1)))
                {
                    Console.WriteLine("The bee got lost!");

                    break;
                }

                if (beehive[beeRow, beeCol] == 'f')
                {
                    flowers++;
                }
                else if (beehive[beeRow, beeCol] == 'O')
                {
                    beehive[beeRow, beeCol] = '.';
                    flowers++;
                    beeRow++;
                }

                command = Console.ReadLine();
            }

            if (flowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }

            PrintSquare(beehive);
        }

        private static void PrintSquare(char[,] beehive)
        {
            for (int row = 0; row < beehive.GetLength(0); row++)
            {
                for (int col = 0; col < beehive.GetLength(1); col++)
                {
                    Console.Write($"{beehive[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        static char[,] FillSquare(int length, ref int beeRow, ref int beeCol)
        {
            char[,] square = new char[length, length];

            for (int row = 0; row < square.GetLength(0); row++)
            {
                char[] squareData = Console.ReadLine().ToCharArray();
                for (int col = 0; col < square.GetLength(1); col++)
                {
                    square[row, col] = squareData[col];

                    if (squareData[col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            return square;
        }
    }
}
