﻿using System;

namespace _08._Town_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            string townName = Console.ReadLine();
            double population = double.Parse(Console.ReadLine());
            double area = double.Parse(Console.ReadLine());


            Console.WriteLine($"Town {townName} has population of {population} and area {area} square km.");

        }
    }
}
