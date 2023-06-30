namespace _01.TBC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private const char VisitetSymbol = 'v';
        private const char DirtSymbol = 'd';

        static void Main(string[] args)
        {

            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var map = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var rowElements = Console.ReadLine();

                for (int c = 0; c < rowElements.Length; c++)
                {
                    map[r, c] = rowElements[c];
                }
            }

            var tunnels = 0;
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if (IsDirt(map, row, col) || IsVisited(map, row, col))
                    {
                        continue;
                    }

                    ExploreTunnel(map, row, col);

                    tunnels += 1;
                }
            }

            Console.WriteLine(tunnels);
        }

        private static void ExploreTunnel(char[,] map, int row, int col)
        {
            if (IsOutSide(map,row,col) || IsDirt(map, row, col) || IsVisited(map, row, col))
            {
                return;
            }

            map[row, col] = VisitetSymbol;

            ExploreTunnel(map, row - 1, col);
            ExploreTunnel(map, row + 1, col);
            ExploreTunnel(map, row, col - 1);
            ExploreTunnel(map, row, col + 1);
            ExploreTunnel(map, row - 1, col - 1);
            ExploreTunnel(map, row - 1, col + 1);
            ExploreTunnel(map, row + 1, col - 1);
            ExploreTunnel(map, row + 1, col + 1);
        }

        private static bool IsOutSide(char[,] map, int row, int col)
        => row < 0 || row >= map.GetLength(0) || col < 0 || col >= map.GetLength(1);

        private static bool IsDirt(char[,] map, int row, int col)
       => map[row, col] == DirtSymbol;

        private static bool IsVisited(char[,] map, int row, int col)
       => map[row, col] == VisitetSymbol;

    }
}