using System;
using System.Linq;

namespace _08.MagicNum
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] numbers = Console.ReadLine().Split().Select(long.Parse).ToArray();
            long n = int.Parse(Console.ReadLine());
            

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int g = i + 1; g < numbers.Length; g++)
                {
                    if (numbers[i] + numbers[g] == n)
                    {
                        Console.WriteLine($"{numbers[i]} {numbers[g]}"); 
                    }
                }
                
            }
        }
    }
}
