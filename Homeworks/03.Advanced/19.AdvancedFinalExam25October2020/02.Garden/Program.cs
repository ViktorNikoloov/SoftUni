using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int gardenRow = input[0];
            int gardenCol = input[1];


            int[,] garden = ReadMatrix(gardenRow, gardenCol);
            int rowLength = garden.GetLength(0);
            int colLength = garden.GetLength(1);

            Dictionary<int, int> flowersPositions = new Dictionary<int, int>();

            string command = Console.ReadLine();
            while (command != "Bloom Bloom Plow")
            {
                int[] flowerPosition = command.Split().Select(int.Parse).ToArray();
                int flowerRow = flowerPosition[0];
                int flowerCol = flowerPosition[1];

                bool isOutsideTheGarder = isOutside(flowerRow, flowerCol, rowLength, colLength);
                if (isOutsideTheGarder)
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    garden[flowerRow, flowerCol] = 1;
                    flowersPositions.Add(flowerRow, flowerCol);
                }

                command = Console.ReadLine();
            }

            FlowersBloom(garden, flowersPositions);

            PrintMatrix(garden);
        }

        static int[,] ReadMatrix(int n, int m)
        {
            int[,] matrix = new int[n, m];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
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

        private static void FlowersBloom(int[,] garden, Dictionary<int, int> flowersPositions)
        {
            foreach (var flower in flowersPositions)
            {
                int flowerRow = flower.Key;
                int flowerCol = flower.Value;

                for (int i = flowerRow + 1; i < garden.GetLength(0); i++)
                {
                    int bloom = garden[i, flowerCol];

                    if (garden[i, flowerCol] >= 0)
                    {
                        garden[i, flowerCol] += 1;
                    }
                }
                for (int i = flowerRow - 1; i >= 0; i--)
                {
                    if (garden[i, flowerCol] >= 0)
                    {
                        garden[i, flowerCol] += 1;
                    }
                }

                for (int i = flowerCol + 1; i < garden.GetLength(1); i++)
                {
                    if (garden[flowerRow, i] >= 0)
                    {
                        garden[flowerRow, i] += 1;
                    }
                }
                for (int i = flowerCol - 1; i >= 0; i--)
                {
                    if (garden[flowerRow, i] >= 0)
                    {
                        garden[flowerRow, i] += 1;
                    }
                }

            }
        }

    }
}