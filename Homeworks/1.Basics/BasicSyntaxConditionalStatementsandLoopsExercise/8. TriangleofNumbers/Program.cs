using System;

namespace _8._TriangleofNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int endNum = int.Parse(Console.ReadLine());
            int count = 1;
            for (int i = 1; i <= endNum; i++)
            {
                for (int a = 1; a <= count; a++)
                {
                    Console.Write(i + " ");
                }
                count++;
                Console.WriteLine();
            }
        }
    }
}
