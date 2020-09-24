using System;

namespace _11._SortNumbersMore
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numThree = int.Parse(Console.ReadLine());

            int firstNum = 0;
            int secondNum = 0;
            int thirdNum = 0;

            if (numOne > numTwo && numOne > numThree)
            {
                firstNum = numOne;
            }
            else if (numTwo > numOne && numTwo > numThree)
            {
                firstNum = numTwo;
            }
            else if (numThree > numTwo && numThree > numOne)
            {
                firstNum = numThree;
            }

            if (numOne < numTwo && numOne < numThree)
            {
                thirdNum = numOne;
            }
            else if (numTwo < numOne && numTwo < numThree)
            {
                thirdNum = numTwo;
            }
            else if (numThree < numTwo && numThree < numOne)
            {
                thirdNum = numThree;
            }

            if (numOne < firstNum && numOne > thirdNum)
            {
                secondNum = numOne;
            }
            else if (numTwo < firstNum && numOne > thirdNum)
            {
                secondNum = numTwo;
            }
            else if (numThree < firstNum && numOne > thirdNum)
            {
                secondNum = numThree;
            }


            Console.WriteLine(firstNum);
            Console.WriteLine(secondNum);
            Console.WriteLine(thirdNum);
        }
    }
}
