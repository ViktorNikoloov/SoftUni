using System;

namespace _04.SymbolinMatrix
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            char currSymbol = ' ';
            bool isMatch = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    currSymbol = matrix[row, col];
                    if (symbol == currSymbol)
                    {
                        isMatch = true;
                        Console.WriteLine($"({row}, {col})");
                        break;
                        
                    }
                }

                if (isMatch)
                {
                    Console.WriteLine();
                    return;
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix ");

        }

        
    }
}
