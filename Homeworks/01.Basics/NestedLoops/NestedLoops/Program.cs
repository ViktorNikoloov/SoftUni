﻿using System;

namespace NestedLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int hour = 0; hour <= 23; hour++)
            {
                for (int minutes = 0; minutes <= 59; minutes++)
                {
                    Console.WriteLine($"{hour}:{minutes}");
                }
            }

        }
    }
}