using System;
using System.Dynamic;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            char[,] chessBoard = new char[n, n];
            FillMatrix(chessBoard);

            int counteReplaced = 0;
            int rowKiller = 0;
            int colKiller = 0;
            while (true)
            {
                int maxAttacks = 0;
                for (int row = 0; row < chessBoard.GetLength(0); row++)
                {
                    for (int col = 0; col < chessBoard.GetLength(1); col++)
                    {
                        char currChar = chessBoard[row, col];
                        int countAttacks = 0;
                        countAttacks = GetAttacks(chessBoard, row, col, currChar, countAttacks);

                        if (countAttacks > maxAttacks)
                        {
                            maxAttacks = countAttacks;
                            rowKiller = row;
                            colKiller = col;

                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    chessBoard[rowKiller, colKiller] = '0';
                    counteReplaced++;
                }
                else
                {
                    Console.WriteLine(counteReplaced);
                    break;
                }
            }

        }

        private static int GetAttacks(char[,] chessBoard, int row, int col, char currChar, int countAttacks)
        {
            if (currChar == 'K')
            {
                if (IsInside(chessBoard, row - 2, col - 1) && chessBoard[row - 2, col - 1] == 'K')
                {
                    countAttacks++;
                }
                if (IsInside(chessBoard, row - 2, col + 1) && chessBoard[row - 2, col + 1] == 'K')
                {
                    countAttacks++;

                }
                if (IsInside(chessBoard, row + 2, col - 1) && chessBoard[row + 2, col - 1] == 'K')
                {
                    countAttacks++;

                }
                if (IsInside(chessBoard, row + 2, col + 1) && chessBoard[row + 2, col + 1] == 'K')
                {
                    countAttacks++;

                }
                if (IsInside(chessBoard, row - 1, col - 2) && chessBoard[row - 1, col - 2] == 'K')
                {
                    countAttacks++;

                }
                if (IsInside(chessBoard, row - 1, col + 2) && chessBoard[row - 1, col + 2] == 'K')
                {
                    countAttacks++;

                }
                if (IsInside(chessBoard, row + 1, col - 2) && chessBoard[row + 1, col - 2] == 'K')
                {
                    countAttacks++;

                }
                if (IsInside(chessBoard, row + 1, col + 2) && chessBoard[row + 1, col + 2] == 'K')
                {
                    countAttacks++;

                }
            }

            return countAttacks;
        }

        private static void FillMatrix(char[,] chessBoard)
        {
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessBoard[row, col] = rowData[col];
                }
            }
        }

        private static void PrintMatrix(char[,] chessBoard)
        {
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    Console.Write(chessBoard[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(char[,] chessBoard, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < chessBoard.GetLength(0) && targetCol >= 0 && targetCol < chessBoard.GetLength(1);
        }
    }
}
