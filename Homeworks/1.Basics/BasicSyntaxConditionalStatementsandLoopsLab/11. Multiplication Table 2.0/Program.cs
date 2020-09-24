using System;

namespace Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());

            for (int i = numTwo; i <= 10; i++)
            {
                if (numTwo > 10)
                {
                    break;
                }
                Console.WriteLine($"{numOne} X {i} = {numOne * i}");
            }
            if (numTwo > 10)
            {

            Console.WriteLine($"{numOne} X {numTwo} = {numOne * numTwo}");
            }
        }
    }
}
