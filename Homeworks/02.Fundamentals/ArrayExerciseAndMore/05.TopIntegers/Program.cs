using System;
using System.Linq;

namespace _05.TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        
        {
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            string topInteger = "";
         

            for (int i = 0; i < integers.Length; i++) //1 4 3 2
            {
                bool isTopInteger = true;

                for (int j = i + 1; j < integers.Length; j++)
                {
                    if (integers[i] <= integers[j])
                    {
                        isTopInteger = false;
                        break;
                    }
                    
                }
                if (isTopInteger)
                {
                    topInteger += integers[i] + " ";
                }

            }

            Console.WriteLine(topInteger);
        }
    }
}
