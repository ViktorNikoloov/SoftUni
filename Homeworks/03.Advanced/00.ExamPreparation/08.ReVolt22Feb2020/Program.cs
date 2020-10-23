using System;

namespace _08.ReVolt22Feb2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int numberofCommands = int.Parse(Console.ReadLine());
            int playerRow = 0;
            int playerCol = 0;

            char[,] matrix = ReadMatrix(n, ref playerRow, ref playerCol);
            matrix[playerRow, playerCol] = '-';

            for (int i = 0; i < numberofCommands; i++)
            {
                string command = Console.ReadLine();
                bool isGoOutsdie = IsOutside(playerRow, playerCol, matrix.GetLength(0), matrix.GetLength(1));
                Movement(ref playerRow, ref playerCol, command);
                if (isGoOutsdie)
                {
                    if (command == "up")
                    {
                        if (playerRow <= 0)
                        {
                            playerRow = matrix.GetLength(0) - 1;
                        }
                        else
                        {
                            playerRow--;
                        }

                    }
                    else if (command == "down")
                    {
                        if (playerRow >= matrix.GetLength(0) - 1)
                        {
                            playerRow = 0;
                        }
                        else
                        {
                            playerRow++;
                        }

                    }
                    else if (command == "left")
                    {
                        if (playerCol <= 0)
                        {
                            playerCol = matrix.GetLength(1) - 1;
                        }
                        else
                        {
                            playerCol--;
                        }
                    }
                    else if (command == "right")
                    {
                        if (playerCol >= matrix.GetLength(1) - 1)
                        {
                            playerCol = 0;
                        }
                        else
                        {
                            playerCol++;
                        }
                    }

                }
                
                char currSpot = matrix[playerRow, playerCol];
                if (currSpot == 'B')
                {

                    if (IsOutside(playerRow, playerCol, matrix.GetLength(0), matrix.GetLength(1)))
                    {
                        if (command == "up")
                        {
                            if (playerRow <= 0)
                            {
                                playerRow = matrix.GetLength(0) - 1;
                            }
                            else
                            {
                                playerRow--;
                            }

                        }
                        else if (command == "down")
                        {
                            if (playerRow >= matrix.GetLength(0) - 1)
                            {
                                playerRow = 0;

                            }
                            else
                            {
                                playerRow++;

                            }

                        }
                        else if (command == "left")
                        {
                            if (playerCol <= 0)
                            {
                                playerCol = matrix.GetLength(1) - 1;
                            }
                            else
                            {
                                playerCol--;
                            }
                        }
                        else if (command == "right")
                        {
                            if (playerCol >= matrix.GetLength(1) - 1)
                            {
                                playerCol = 0;
                            }
                            else
                            {
                                playerCol++;
                            }
                        }
                    }
                    else
                    {
                        Movement(ref playerRow, ref playerCol, command);
                    }
                }
                else if (currSpot == 'T')
                {
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
                }
                if (currSpot == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    Console.WriteLine("Player won!");
                    PrintMatrix(matrix);
                    return;
                }
            }

            matrix[playerRow, playerCol] = 'f';
            Console.WriteLine("Player lost!");
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

        static bool IsOutside(int row, int col, int rowLength, int colLength)
        {
            bool isInside = false;
            if (!(row > 0
                && row < rowLength - 1
                && col > 0
                && col < colLength - 1))
            {

                isInside = true;
            }
            return isInside;
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
                    if (currSymbol == 'f')
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