using System;
using System.Linq;

namespace _02._2X2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = ReadIntArray(" ");
            string[,] matrix = new string[sizes[0], sizes[1]];
            bool isEqual = false;
            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                   
                    if ((matrix[row, col] == matrix[row, col + 1]) && (matrix[row, col] == matrix[row + 1, col]) &&(matrix[row, col + 1] == matrix[row + 1, col + 1]))
                    {
                        isEqual = true;
                        counter++;
                    }
                }
            }
            
            Console.WriteLine(counter);

        }

        static int[] ReadIntArray(string separator)
        {
            int[] output = Console.ReadLine().Split($"{separator}", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            return output;
        }
    }
}
