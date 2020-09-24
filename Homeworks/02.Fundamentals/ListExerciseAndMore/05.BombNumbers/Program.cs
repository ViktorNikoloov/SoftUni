using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> specialNumAndPower = Console.ReadLine().Split().Select(int.Parse).ToList();
            int special = specialNumAndPower[0];
            int power = specialNumAndPower[1];

            int bombIndex = numbers.IndexOf(special);
            while (bombIndex != -1)
            {
                int leftIndex = bombIndex - power;
                int rightIndex = bombIndex + power;
                
                if (leftIndex < 0)
                {
                    leftIndex = 0;
                }
                else if (rightIndex > numbers.Count - 1)
                {
                    rightIndex = numbers.Count - 1;
                }
                numbers.RemoveRange(leftIndex, rightIndex - leftIndex + 1);
               
                bombIndex = numbers.IndexOf(special);

            }

             Console.WriteLine(numbers.Sum());
        }
    }
}
