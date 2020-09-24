using System;

namespace _07.NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Print(num);
        }

        static void Print(int num)
        {
            for (int i = 0; i < num; i++)
            {


                for (int g = 0; g < num; g++)
                {
                    Console.Write(num + " ");

                }
                Console.WriteLine();
            }
        }
    }
}
