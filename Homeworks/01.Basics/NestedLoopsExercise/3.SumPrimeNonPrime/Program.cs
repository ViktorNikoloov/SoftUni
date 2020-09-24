using System;

namespace _3.SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            int prime = 0;
            int nonprime = 0;

            string input = Console.ReadLine();
            while (input != "stop")
            {
                int num = int.Parse(input);
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else if (num <= 1)
                {
                    nonprime += num;
                }
                else if (num == 2)
                {
                    prime += num;
                }
                else
                {
                    bool isPrime = true;
                    for (int i = 2; i <= num / 2; i++)
                    {
                        if (num % i == 0)
                        {
                            isPrime = false;
                            break;
                        }

                    }
                    if (isPrime)
                    {
                        prime += num;
                    }
                    else
                    {
                        nonprime += num;
                    }

                }


                input = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {prime}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonprime}");

        }
    }
}
