﻿using System;

namespace _01._Integer_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int fourth = int.Parse(Console.ReadLine());

            long result = ((first + second) / third) * fourth;

            Console.WriteLine(result);
        }
    }
}
