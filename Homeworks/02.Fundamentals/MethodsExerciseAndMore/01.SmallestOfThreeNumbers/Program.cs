using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int one = int.Parse(Console.ReadLine());
            int two = int.Parse(Console.ReadLine());
            int three = int.Parse(Console.ReadLine());
            Console.WriteLine(FindTheSmallestNum(one, two, three));
        }

        static int FindTheSmallestNum(int first, int second, int third)
        {
            int smallestNum = int.MaxValue;
            if (first < second && first < third)
            {
                smallestNum = first;
            }
            else if (first > second && second < third)
            {
                smallestNum = second;
            }
            else
            {
                smallestNum = third;
            }
            return smallestNum;
        }
    }
}
