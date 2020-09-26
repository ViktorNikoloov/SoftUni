using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int firstDiagonal = 0;
            int secondDiagonal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowData = ReadIntArray(" ");
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                firstDiagonal += matrix[col, col];
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                secondDiagonal += matrix[row, matrix.GetLength(0) - 1 - row];
                
            }

            int result = Math.Abs(firstDiagonal - secondDiagonal);
            Console.WriteLine(result);
        }

        static int[] ReadIntArray(string separator)
        {
            int[] output = Console.ReadLine().Split($"{separator}", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            return output;
        }
    }
}
