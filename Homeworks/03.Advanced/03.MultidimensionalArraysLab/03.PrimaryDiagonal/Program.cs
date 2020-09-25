using System;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int[,] matrix = new int[input, input];
            int result = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = ReadIntArray(Console.ReadLine(), " ");
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                result += matrix[row, row];
            }

            Console.WriteLine(result);
        }

        static int[] ReadIntArray(string input, string separator)
        {
            return input.Split($"{separator}", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
    }
}
