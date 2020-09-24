using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //5,7 11
            long input = long.Parse(Console.ReadLine());

            for (int i = 1; i <= input; i++)
            {
                int sum = 0;
                string strNum = "";
                strNum += i;

                for (int j = 0; j <= strNum.Length - 1; j++)
                {
                    char charNum = strNum[j];
                    string strCurrNum = "";
                    strCurrNum += charNum;
                    int currSum = int.Parse(strCurrNum);
                    sum += currSum;
                }
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }

        }
    }
}
