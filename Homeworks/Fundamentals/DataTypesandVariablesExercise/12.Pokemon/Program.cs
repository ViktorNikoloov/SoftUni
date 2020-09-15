using System;
using System.Numerics;

namespace _12.Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            byte y = byte.Parse(Console.ReadLine());

            int pokeTargrts = 0;
            int number = n;
            
            while (number >= m)
            {
                if (number == n / 2 && y > 0)
                {
                    number /= y;

                    if (number < m)
                    {
                        break;
                    }
                    
                }

                number -= m;
                pokeTargrts++;
            }
            Console.WriteLine(number);
            Console.WriteLine(pokeTargrts);
        }
    }
}
