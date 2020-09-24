using System;

namespace _14.From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            byte input = byte.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                string strNum = Console.ReadLine();
                long leftSum = 0;
                long rightSum = 0;
                byte count = 0;

                for (int g = 0; g < strNum.Length; g++)
                {
                    count++;
                    if (strNum[g] == 45)
                    {
                        continue;
                    }
                    if (strNum[g] == 32)
                    {
                        break;
                    }
                    leftSum += int.Parse(strNum[g].ToString());
                }

                for (int f = 0; f < strNum.Length - count; f++)
                {
                    if (strNum[f + count] == 45)
                    {
                        continue;
                    }
                    rightSum += int.Parse(strNum[f + count].ToString());
                }
                if (leftSum >= rightSum)
                {
                    Console.WriteLine(leftSum);
                }
                else
                {
                    Console.WriteLine(rightSum);
                }

            }
        }
    }
}

