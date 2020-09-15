using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                bool isDevivide = SumDigitDivide(i, 8);
                bool isItOdd = IsItHoldOddDigit(i);

                if (isDevivide == true && isItOdd == true)
                {
                    Console.WriteLine(i);
                }
            }

        }

        static bool SumDigitDivide(int number, int devideNumber)
        {
            string strNum = number.ToString();
            int sum = 0;

            for (int i = 0; i < strNum.Length; i++)
            {
                sum += strNum[i];
            }

            if (sum % devideNumber == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool IsItHoldOddDigit(int number)
        {
            string strNum = number.ToString();
            bool isOddNumber = false;

            for (int i = 0; i < strNum.Length; i++)
            {
                int currNum = strNum[i];
                if (currNum % 2 != 0)
                {
                    isOddNumber = true;
                    break;
                }

            }
            if (isOddNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
