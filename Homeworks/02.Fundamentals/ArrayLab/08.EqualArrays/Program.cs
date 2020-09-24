using System;

namespace _08.EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArr = Console.ReadLine().Split();
            string[] secondArr = Console.ReadLine().Split();
            bool isIndetical = false;
            int sum = 0;
            int index = 0;

            for (int i = 0; i < firstArr.Length; i++)
            {
                //int currFirstNum = int.Parse(firstArr[i]);
                //int currSecondNum = int.Parse(secondArr[i]);

                if (firstArr[i] == secondArr[i])
                {
                    //sum += currFirstNum;
                    sum += int.Parse(firstArr[i]);
                }
                else
                {
                    isIndetical = true;
                    index = i;
                    break;
                }
              
            }
            if (isIndetical)
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {index} index");
            }
            else
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }

        }
    }
}
