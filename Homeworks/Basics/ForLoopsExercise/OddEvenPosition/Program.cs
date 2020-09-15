using System;

namespace OddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = double.Parse(Console.ReadLine());

            //double OddSum = 0;
            //double OddMin = double.MaxValue;   //{"No"}
            //double OddMax = double.MinValue;  // {“No”}

            double EvenSum = 0;
            double EvenMin = double.MaxValue; // {“No”}
            double EvenMax = double.MinValue; // {“No”}


            for (int i = 1; i < input; i++)
            {
                double numbers = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    EvenSum += i;
                    if (i > EvenMax)
                    {
                        EvenMax = i;
                    }
                    if (i < EvenMin)
                    {
                        EvenMin = i;
                    }
                }

            }

            Console.WriteLine(EvenMin);
            Console.WriteLine(EvenMax);
            Console.WriteLine(EvenSum);
        }
    }
}
