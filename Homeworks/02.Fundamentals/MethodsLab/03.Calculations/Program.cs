using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string sign = Console.ReadLine();
            double numOne = double.Parse(Console.ReadLine());
            double numTwo = double.Parse(Console.ReadLine());
            

            Calculator(numOne, numTwo, sign);
        }

        static void Calculator(double firstNum, double secondNum, string sign)
        {
            double result = 0;
            if (sign == "+")
            {
                Console.WriteLine(result = firstNum + secondNum); 
            }
            else if (sign == "-")
            {
                Console.WriteLine(result = firstNum - secondNum);
            }
            else if (sign == "*")
            {
                Console.WriteLine(result = firstNum * secondNum);
            }
            else if (sign == "/")
            {
                Console.WriteLine(result = firstNum / secondNum);
            }
        }
    }
}
