using System;

namespace _06.StrongNumberLength
{
    class Program
    {
        static void Main(string[] args)
        {
           int number = int.Parse(Console.ReadLine());
            int factorial = number;
            int totalSum = 0;
            string strNum = "";
            strNum += number;

            for (int i = 0; i < strNum.Length; i++)
            {
                int currNum = factorial % 10;
                factorial /= 10;
                int sum = currNum;
                for (int j = 1; j < currNum; j++)
                {
                    sum *= j;
                }
                totalSum += sum;
            }
            if (number == totalSum)
            {
            Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
