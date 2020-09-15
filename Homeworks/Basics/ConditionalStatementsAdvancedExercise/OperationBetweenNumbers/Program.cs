using System;

namespace OperationBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberOne = double.Parse(Console.ReadLine());
            double numberTwo = double.Parse(Console.ReadLine());
            char typeInput = char.Parse(Console.ReadLine());
            //char typeOutput = ',';
            double calculation = 0;
            string evenOrOdd = "";
            bool isValid = true;


            //„+“, „-“, „*“, „/“, „%“

            switch (typeInput)
            {
                case '+':
                    //typeOutput = '+';
                    calculation = numberOne + numberTwo;
                    if (calculation % 2 == 0)
                    {
                        evenOrOdd = "even";
                    }
                    else
                    {
                        evenOrOdd = "odd";
                    }
                    break;

                case '-':
                   // typeOutput = '-';
                    calculation = numberOne - numberTwo;
                    if (calculation % 2 == 0)
                    {
                        evenOrOdd = "even";
                    }
                    else
                    {
                        evenOrOdd = "odd";
                    }
                    break;

                case '*':
                    // typeOutput = '-';
                    calculation = numberOne * numberTwo;
                    if (calculation % 2 == 0)
                    {
                        evenOrOdd = "even";
                    }
                    else
                    {
                        evenOrOdd = "odd";
                    }
                    break;

                case '/':
                    // typeOutput = '/';
                    if (numberOne == 0 || numberTwo == 0)
                    {
                        isValid = false;                     
                    }
                    else if (numberTwo == 0)
                    {
                        isValid = false;
                    }
                    else
                    {
                        calculation = numberOne / numberTwo;
                    }
                    break;

                case '%':
                    // typeOutput = '%';
                    if (numberOne == 0)
                    {
                        isValid = false;
                       
                    }
                    else if (numberTwo == 0)
                    {
                        isValid = false;
                    }
                    else
                    {
                        calculation = numberOne % numberTwo;
                    }
                    break;
            }

            if (isValid == false)
            {
                if (numberOne == 0)
                {
                    Console.WriteLine($"Cannot divide {numberTwo} by zero");
                }
                else if (numberTwo == 0)
                {
                    Console.WriteLine($"Cannot divide {numberOne} by zero");
                }

            }
            else if (typeInput == '+' || typeInput == '-' || typeInput == '*')
            {
                Console.WriteLine($"{numberOne} {typeInput} {numberTwo} = {calculation} - {evenOrOdd}");
            }
            else if (typeInput == '/')
            {
                Console.WriteLine($"{numberOne} {typeInput} {numberTwo} = {calculation:f2}");
            }
            else if (typeInput == '%')
            {
                Console.WriteLine($"{numberOne} {typeInput} {numberTwo} = {calculation}");
            }
        }
    }
}
