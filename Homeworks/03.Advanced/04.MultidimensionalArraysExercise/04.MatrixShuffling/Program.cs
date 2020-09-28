using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = ReadIntArray(" ");
            string[,] matrix = new string[sizes[0], sizes[1]];
            string swap = string.Empty;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            string[] command = Console.ReadLine().Split(); //swap 0 0 1 1
            while (command[0] != "END")
            {
                if (command[0] !=("swap") 
                    || command.Length != 5 
                    || int.Parse(command[1]) < 0
                    || int.Parse(command[2]) < 0 
                    || int.Parse(command[3]) < 0
                    || int.Parse(command[4]) < 0
                    || int.Parse(command[1]) > matrix.GetLength(0)
                    || int.Parse(command[3]) > matrix.GetLength(0)
                    || int.Parse(command[2]) > matrix.GetLength(1)
                    || int.Parse(command[4]) > matrix.GetLength(1)
                    )
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    int firstRow = int.Parse(command[1]);
                    int firstCol = int.Parse(command[2]);
                    int secondRow = int.Parse(command[3]);
                    int secondCol= int.Parse(command[4]);
                    swap = matrix[secondRow, secondCol];

                    matrix[secondRow, secondCol] = matrix[firstRow, firstCol];
                    matrix[firstRow, firstCol] = swap;

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row, col] + " ");
                        }
                        Console.WriteLine();
                    }

                }

                command = Console.ReadLine().Split();
            }
        }

        static int[] ReadIntArray(string separator)
        {
            int[] output = Console.ReadLine().Split($"{separator}", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            return output;
        }
    }
}
