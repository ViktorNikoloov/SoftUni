using System;
using System.Linq;
using System.Numerics;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = ReadIntArray(" ");
            char[,] snake = new char[sizes[0], sizes[1]];
            int currChar = 0;
            string rowData = Console.ReadLine();

            for (int row = 0; row < snake.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < snake.GetLength(1); col++)
                    {
                        snake[row, col] = rowData[currChar];
                        currChar++;

                        if (currChar == rowData.Length)
                        {
                            currChar = 0;
                        }
                    }

                }
                else
                {
                    for (int col = snake.GetLength(1) - 1; col >= 0; col--)
                    {
                        snake[row, col] = rowData[currChar];
                        currChar++;

                        if (currChar == rowData.Length)
                        {
                            currChar = 0;
                        }

                    }
                    
                }

            }

            for (int row = 0; row < snake.GetLength(0); row++)
            {
                for (int col = 0; col < snake.GetLength(1); col++)
                {
                    Console.Write(snake[row, col]);
                }
                Console.WriteLine();
            }
        }

        static int[] ReadIntArray(string separator)
        {
            int[] output = Console.ReadLine().Split($"{separator}", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            return output;
        }
    }
}
