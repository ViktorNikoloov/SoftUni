using System;
using System.Linq;

namespace _01.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int sum = 0;

            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }

            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sum += matrix[row, col];
                }

            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);

        }
    }
}