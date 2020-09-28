using System;
using System.Data;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            double[][] jagged = new double[n][];

            for (int row = 0; row < jagged.Length; row++)
            {
                int[] rowData = ReadIntArray(" ");
                jagged[row] = new double[rowData.Length];
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = rowData[col];
                }
            }

            for (int row = 0; row < jagged.Length - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] *= 2;
                    }
                    for (int col = 0; col < jagged[row + 1].Length; col++)
                    {
                        jagged[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] /= 2;
                    }
                    for (int col = 0; col < jagged[row + 1].Length; col++)
                    {
                        jagged[row + 1][col] /= 2;
                    }
                }
            }

            string[] command = Console.ReadLine().Split(); //Add {row} {column} {value}
            while (command[0] != "End")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row >= 0
                    && col >= 0
                    && row < jagged.Length
                    && col < jagged[row].Length
                    )
                {
                    if (command[0] == "Add")
                    {
                        jagged[row][col] += value;
                    }
                    else if (command[0] == "Subtract")
                    {
                        jagged[row][col] -= value;
                    }
                }

                command = Console.ReadLine().Split();
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col] + " ");
                }
                Console.WriteLine();
            }

        }

        static int[] ReadIntArray(string separator)
        {
            int[] output = Console.ReadLine().Split($"{separator}", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            return output;
        }
    }
}
