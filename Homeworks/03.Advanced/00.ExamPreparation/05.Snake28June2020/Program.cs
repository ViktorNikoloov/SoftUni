using System;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace _05.Snake28June2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int snakeRow = 0;
            int snakeCol = 0;
            int burrowRow = 0;
            int burrowCol = 0;
            int food = 0;

            char[,] matrix = ReadMatrix(n, ref snakeRow, ref snakeCol, ref burrowRow, ref burrowCol);
            
            while (food < 10)
            {
                string command = Console.ReadLine();
                matrix[snakeRow, snakeCol] = '.';

                Movement(ref snakeRow, ref snakeCol, command);

                if (IsInside(snakeRow, snakeCol, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    break;
                }

                char currSymbol = matrix[snakeRow, snakeCol];
                if (currSymbol == '*')
                {
                    food++;
                }
                if (currSymbol == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';
                    snakeRow = burrowRow;
                    snakeCol = burrowCol;
                }

            }

            if (food >= 10)
            {
                matrix[snakeRow, snakeCol] = 'S';
                Console.WriteLine("You won! You fed the snake.");
            }
            else
            {
                Console.WriteLine("Game over!");
            }

            Console.WriteLine($"Food eaten: {food}");
            PrintMatrix(matrix);
        }

        private static void Movement(ref int snakeRow, ref int snakeCol, string command)
        {
            if (command == "up")
            {
                snakeRow--;
            }
            else if (command == "down")
            {
                snakeRow++;

            }
            else if (command == "left")
            {
                snakeCol--;
            }
            else if (command == "right")
            {
                snakeCol++;
            }
        }

        static bool IsInside(int row, int col, int rowLength, int colLength)
        {
            bool isInside = false;
            if (!(row >= 0
                && row <= rowLength - 1
                && col >= 0
                && col <= colLength - 1))
            {

                isInside = true;
            }
            return isInside;
        }

        static char[,] ReadMatrix(int n, ref int snakeRow, ref int snakeCol, ref int burrowRow, ref int burrowCol)
        {
            char[,] matrix = new char[n, n];
            int burrowCounter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currSymbol = rowData[col];
                    if (currSymbol == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    if (currSymbol =='B')
                    {
                        burrowCounter++;
                        if (burrowCounter == 2)
                        {
                            burrowRow = row;
                            burrowCol = col;
                        }
                    }
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

        }

    }

}

