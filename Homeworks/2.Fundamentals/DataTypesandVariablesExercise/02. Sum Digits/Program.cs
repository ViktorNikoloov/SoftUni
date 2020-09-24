using System;

namespace _02._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            string strInput = "";
            strInput += input;
            int sum = 0;

            for (int i = 0; i < strInput.Length; i++)
            {
                sum += input % 10;
                input /= 10;

            }
            Console.WriteLine(sum);
        }
    }
}
