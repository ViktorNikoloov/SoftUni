using System;

namespace _12._Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10000; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (Math.Abs(num) % 2 == 1)
                {
                    Console.WriteLine("Please write an even number.");
                    continue;
                }
                else
                {
                    Console.WriteLine($"The number is: {Math.Abs(num)}");
                    break;
                }
            }

        }
        }
    }

