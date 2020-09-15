using System;

namespace OddEvenPosition2
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = double.Parse(Console.ReadLine());

            double oddSum = 0;
            double oddMin = double.MaxValue;   //{"No"}
            double oddMax = double.MinValue;  // {“No”}

            double evenSum = 0;
            double evenMin = double.MaxValue; // {“No”}
            double evenMax = double.MinValue; // {“No”}




            for (int i = 1; i <= input; i++)
            {
                double numbers = double.Parse(Console.ReadLine());


                if (i % 2 == 0)
                {
                    evenSum += numbers;

                    if (numbers > evenMax)
                    {
                        evenMax = numbers;
                    }
                    if (numbers < evenMin)
                    {
                        evenMin = numbers;
                    }
                }
                else
                {
                    oddSum += numbers;

                    if (numbers > oddMax)
                    {
                        oddMax = numbers;
                    }
                    if (numbers < oddMin)
                    {
                        oddMin = numbers;
                    }
                }
            }
            Console.WriteLine($"OddSum={oddSum:f2},");
            if (oddSum == 0)
            {
                Console.WriteLine($"OddMin={"No"},");
                Console.WriteLine($"OddMax={"No"},");
            }
            else
            {
                Console.WriteLine($"OddMin={oddMin:f2},");
                Console.WriteLine($"OddMax={oddMax:f2},");
            }

            Console.WriteLine($"EvenSum={evenSum:f2},");

            if (evenSum == 0)
            {
                Console.WriteLine($"EvenMin={"No"},");
                Console.WriteLine($"EvenMax={"No"}");
            }
            else
            {
                Console.WriteLine($"EvenMin={evenMin:f2},");
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }

            //if (input == 0)
            //{

            //    Console.WriteLine($"OddSum={oddSum:f2},");
            //    Console.WriteLine($"OddMin={"No"},");
            //    Console.WriteLine($"OddMax={"No"},");
            //    Console.WriteLine($"EvenSum={evenSum:f2},");
            //    Console.WriteLine($"EvenMin={"No"},");
            //    Console.WriteLine($"EvenMax={"No"}");
            //}
            //else if (oddSum == oddMin && evenSum == evenMin)
            //{
            //    Console.WriteLine($"OddSum={oddSum:f2},");
            //    Console.WriteLine($"OddMin={oddMin:f2},");
            //    Console.WriteLine($"OddMax={oddMax:f2},");
            //    Console.WriteLine($"EvenSum={evenSum:f2},");
            //    Console.WriteLine($"EvenMin={evenMin:f2},");
            //    Console.WriteLine($"EvenMax={evenMax:f2}");
            //}
            //else if (oddSum == oddMin)
            //{
            //    Console.WriteLine($"OddSum={oddSum:f2},");
            //    Console.WriteLine($"OddMin={oddMin:f2},");
            //    Console.WriteLine($"OddMax={oddMax:f2},");
            //    Console.WriteLine($"EvenSum={evenSum:f2},");
            //    Console.WriteLine($"EvenMin={"No"},");
            //    Console.WriteLine($"EvenMax={"No"}");
            //}

            //else
            //{
            //    Console.WriteLine($"OddSum={oddSum:f2},");
            //    Console.WriteLine($"OddMin={oddMin:f2},");
            //    Console.WriteLine($"OddMax={oddMax:f2},");
            //    Console.WriteLine($"EvenSum={evenSum:f2},");
            //    Console.WriteLine($"EvenMin={evenMin:f2},");
            //    Console.WriteLine($"EvenMax={evenMax:f2}");
            //}

        }
    }
}
