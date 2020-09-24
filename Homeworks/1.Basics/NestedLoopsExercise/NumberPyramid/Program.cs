using System;

namespace NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isEqual = false;
            int end = 1;
            int currNumber = 1;
            while (isEqual == false)
            {
                for (int i = 1; i <= end; i++)
                {
                    Console.Write(currNumber + " ");
                    currNumber++;
                    if (currNumber > number)
                    {
                        isEqual = true;
                        break;
                    }

                }
                end++;
                Console.WriteLine();

            }

        }
    }
}
