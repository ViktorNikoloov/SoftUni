using System;

namespace _14.BookWorm26October2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringInput = Console.ReadLine();
            int lenght = int.Parse(Console.ReadLine());

            int playerRow = 0;
            int playerCol = 0;
            string output = stringInput;

            char[,] matrix = ReadMatrix(lenght, ref playerRow, ref playerCol);

            string command = Console.ReadLine();
            while (command != "end")
            {
                matrix[playerRow, playerCol] = '-';

                Movement(ref playerRow, ref playerCol, command);

                bool isOutsideTheField = isOutside(playerRow, playerCol, matrix.GetLength(0), matrix.GetLength(1));
                if (isOutsideTheField)
                {
                    if (output.Length > 0)
                    {

                        output = output.Remove(output.Length - 1);
                        if (command == "up")
                        {
                            playerRow++;
                        }
                        else if (command == "down")
                        {
                            playerRow--;

                        }
                        else if (command == "left")
                        {
                            playerCol++;
                        }
                        else if (command == "right")
                        {
                            playerCol--;
                        }
                        matrix[playerRow, playerCol] = 'P';

                    }
                }
                else
                {
                    char currLetter = matrix[playerRow, playerCol];
                    if(char.IsLetter(currLetter))
                    {
                        output += currLetter;
                        matrix[playerRow, playerCol] = 'P';
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(output);
            PrintMatrix(matrix);

        }

        private static void Movement(ref int playerRow, ref int playerCol, string command)
        {
            if (command == "up")
            {
                playerRow--;
            }
            else if (command == "down")
            {
                playerRow++;

            }
            else if (command == "left")
            {
                playerCol--;
            }
            else if (command == "right")
            {
                playerCol++;
            }
        }

        static bool isOutside(int row, int col, int rowLength, int colLength)
        {
            bool isOutside = false;
            if (!(row >= 0
                && row <= rowLength - 1
                && col >= 0
                && col <= colLength - 1))
            {
                isOutside = true;
            }
            return isOutside;
        }

        static char[,] ReadMatrix(int n, ref int playerRow, ref int playerCol)
        {
            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currSymbol = rowData[col];
                    if (currSymbol == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
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
