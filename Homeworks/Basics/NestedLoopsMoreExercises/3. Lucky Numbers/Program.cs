using System;

namespace _3._Lucky_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= 9; i++)
            {
                for (int a = 1; a <= 9; a++)
                {
                    for (int s = 1; s <= 9; s++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            if ((number % (i + a) == 0) && i + a == s + d)
                            {
                                Console.Write($"{i}{a}{s}{d} ");
                            }

                        }
                       
                    }
                   
                }
              
            }

        }
    }
}
