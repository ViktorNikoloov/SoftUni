using System;

namespace _11.PresentDelivery17December2019
{
    class Program
    {
        static void Main(string[] args)
        {

            int presentsCount = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            int santaRow = 0;
            int santaCol = 0;
            int kidsMustBeHappy = 0;
            int happyKids = 0;

            string[,] neighborhood = ReadMatrix(length, ref santaRow, ref santaCol, ref kidsMustBeHappy);

            string command = Console.ReadLine();
            while (command != "Christmas morning" && presentsCount != 0)
            {
                neighborhood[santaRow, santaCol] = "-";

                Movement(ref santaRow, ref santaCol, command);

                string currSymbol = neighborhood[santaRow, santaCol];

                if (currSymbol == "X")
                {

                }
                else if (currSymbol == "V")
                {
                    presentsCount--;
                    happyKids++;
                }
                else if (currSymbol == "C")
                {
                    bool up = isInside(santaRow - 1, santaCol, neighborhood.GetLength(1), neighborhood.GetLength(0));
                    string upSymbol = neighborhood[santaRow-1, santaCol];

                    bool down = isInside(santaRow+1, santaCol, neighborhood.GetLength(1), neighborhood.GetLength(0));
                    string downSymbol = neighborhood[santaRow+1, santaCol];

                    bool right = isInside(santaRow, santaCol-1, neighborhood.GetLength(1), neighborhood.GetLength(0));
                    string rightSymbol = neighborhood[santaRow, santaCol-1];

                    bool left = isInside(santaRow, santaCol+1, neighborhood.GetLength(1), neighborhood.GetLength(0));
                    string leftSymbol = neighborhood[santaRow, santaCol+1];

                    if (up && upSymbol != "-")
                    {
                        if (presentsCount != 0)
                        {
                            if (upSymbol == "V")
                            {
                                happyKids++;
                            }
                            presentsCount--;
                            neighborhood[santaRow-1, santaCol] = "-";
                        }
                        else
                        {
                            break;
                        }

                    }
                    if (down && downSymbol != "-")
                    {
                        if (presentsCount != 0)
                        {
                            if (downSymbol == "V")
                            {
                                happyKids++;
                            }
                            presentsCount--;
                            neighborhood[santaRow+1, santaCol] = "-";
                        }
                        else
                        {
                            break;
                        }

                    }
                    if (right && rightSymbol != "-")
                    {
                        if (presentsCount != 0)
                        {
                            if (rightSymbol == "V")
                            {
                                happyKids++;
                            }
                            presentsCount--;
                            neighborhood[santaRow, santaCol-1] = "-";

                        }
                        else
                        {
                            break;
                        }

                    }
                    if (left && leftSymbol != "-")
                    {
                        if (presentsCount != 0)
                        {
                            if (leftSymbol == "V")
                            {
                                happyKids++;
                            }
                            presentsCount--;
                            neighborhood[santaRow, santaCol+1] = "-";
                        }
                        else
                        {
                            break;
                        }
                        
                    }
                }
                
                if (presentsCount <= 0)
                {
                    break;
                }

                command = Console.ReadLine();
            }

            neighborhood[santaRow, santaCol] = "S";

            if (presentsCount <= 0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }

            PrintMatrix(neighborhood);

            if (kidsMustBeHappy == happyKids)
            {
                Console.WriteLine($"Good job, Santa! {happyKids} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {kidsMustBeHappy - happyKids} nice kid/s.");
            }

        }

        private static void Movement(ref int row, ref int col, string command)
        {
            if (command == "up")
            {
                row--;
            }
            else if (command == "down")
            {
                row++;

            }
            else if (command == "left")
            {
                col--;
            }
            else if (command == "right")
            {
                col++;
            }
        }

        static bool isInside(int row, int col, int rowLength, int colLength)
        {
            bool isInside = false;
            if (row >= 0
                && row <= rowLength - 1
                && col >= 0
                && col <= colLength - 1)
            {
                isInside = true;
            }
            return isInside;
        }

        static string[,] ReadMatrix(int n, ref int someRow, ref int someCol, ref int niceKidsCount)
        {
            string[,] square = new string[n, n];

            for (int row = 0; row < square.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split();
                for (int col = 0; col < square.GetLength(1); col++)
                {
                    string currSymbol = rowData[col];
                   
                    if (currSymbol == "S")
                    {
                        someRow = row;
                        someCol = col;
                    }
                    if (currSymbol == "V")
                    {
                        niceKidsCount++;
                    }

                    square[row, col] = rowData[col];
                }
            }

            return square;
        }

        static void PrintMatrix(string[,] matrix)
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
    }
}
