using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int currYield = 0;
            int dayCount = 0;
            while (startingYield >= 100)
            {
                dayCount++;
                currYield += startingYield - 26;
                startingYield -= 10;
            }
            if (startingYield < 100)
            {
                if (currYield >= 26)
                {
                    currYield -= 26;
                }
                
            }
            Console.WriteLine(dayCount);
            Console.WriteLine(currYield);
        }
    }
}
