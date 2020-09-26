using System;
using System.Linq;

namespace _07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[n][];

            for (int row = 0; row < pascalTriangle.Length; row++)
            {
                pascalTriangle[row] = new long[row + 1];
                pascalTriangle[row][0] = 1;
                pascalTriangle[row][pascalTriangle[row].Length - 1] = 1;
                for (int col = 1; col < pascalTriangle[row].Length - 1; col++)
                {
                    pascalTriangle[row][col] = pascalTriangle[row - 1][col] + pascalTriangle[row - 1][col - 1];
                }
            }

            //for (int row = 0; row < pascalTriangle.Length; row++)
            //{
            //    for (int col = 0; col < pascalTriangle[row].Length; col++)
            //    {
            //        Console.Write(pascalTriangle[row][col] + " ");
            //    }
            //    Console.WriteLine();
            //}

            foreach (long[] row in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
