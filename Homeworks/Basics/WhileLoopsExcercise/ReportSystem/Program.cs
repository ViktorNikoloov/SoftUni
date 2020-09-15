using System;

namespace ReportSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(37%2);
            //Сумата, която се очаква да бъде събрана от продажбите.
            int sum = int.Parse(Console.ReadLine());
            bool isValid = false;
            int counter = 0;
            int totalSum = 0;
            int cashSum = 0;
            int cashCounter = 0;
            int cardSum = 0;
            int cardCounter = 0;
            //На всеки следващ ред цените на предметите .
            //До получаване на командата "End" или докато не се съберат нужните средства.

            while (totalSum < sum)
            {
                //Винаги се редуват: плащане в брой и плащане с карта. 
                //Над 100лв. не може да се плати в брой.
                //Под 10лв. не може да се плати с кредитна карта.

                counter++;
                string input = Console.ReadLine();
                if (input == "End")
                {
                    isValid = true;
                    break;
                }
                int inputNum = int.Parse(input);

                if (counter % 2 == 1)
                {
                    if (inputNum > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        cashSum += inputNum;
                        cashCounter++;
                        totalSum += inputNum;
                    }
                }
                else
                {
                    if (inputNum < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        cardSum += inputNum;
                        cardCounter++;
                        totalSum += inputNum;
                    }
                }
            }

            if (isValid == true)
            {
                Console.WriteLine("Failed to collect required money for charity.");
            }
            else
            {
                Console.WriteLine($"Average CS: {(1.0 * cashSum / cashCounter):f2}");
                Console.WriteLine($"Average CC: {(1.0 * cardSum / cardCounter):f2}");
            }
        }
    }
}
