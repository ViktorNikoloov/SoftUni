using System;
using System.Linq;

namespace _06.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int[][] jagget = new int[n][];

            for (int row = 0; row < jagget.Length; row++)
            {
                int[] rowData = ReadIntArray(" ");
                jagget[row] = new int[rowData.Length];
                for (int col = 0; col < jagget[row].Length; col++)
                {
                    jagget[row][col] = rowData[col];
                }
            }

            string[] command = Console.ReadLine().Split();
            while (!command.Contains("END"))
            {
                string action = command[0];
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if ((0 <= row && row < jagget.Length) && (0 <= col && col <= jagget[row].Length)) 
                {
                    switch (command[0])
                    {
                        case "Add":
                            jagget[row][col] += value;
                            break;

                        case "Subtract":
                            jagget[row][col] -= value;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

                command = Console.ReadLine().Split();
            }

            for (int row = 0; row < jagget.Length; row++)
            {
                for (int col = 0; col < jagget[row].Length; col++)
                {
                    Console.Write(jagget[row][col] + " ");
                }

                Console.WriteLine();
            }

            //foreach (var row in jagget)
            //{
            //    Console.WriteLine(string.Join(" ", row));
            //}

        }

        static int[] ReadIntArray(string separator)
        {
            int[] output = Console.ReadLine().Split($"{separator}", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            return output;
        }

    }
}
