using System;

namespace _4._Car_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                for (int a = start; a <= end; a++)
                {
                    for (int s = start; s <= end; s++)
                    {
                        for (int d = start; d <= end; d++)
                        {
                            if (i % 2 == 1 && i > d && (a + s) % 2 == 0 && d % 2 == 0 || i % 2 == 0 && i > d && (a + s) % 2 == 0 && d % 2 == 1)
                            {

                                Console.Write($"{i}{a}{s}{d} ");
                            }

                        }
                    }
                }

            }
        }
    }
}
