using System;

namespace Numbers100to200
{
    class Program
    {
        static void Main(string[] args)
        {
            //Да се напише програма, която чете цяло число, въведено от потребителя и проверява, дали е под 100, между 100 и 200 или над 200. 
            //Да се отпечатат съответно съобщения, като в примерите по-долу:
            int number = int.Parse(Console.ReadLine());

            if (number <= 99)
            {
                Console.WriteLine("Less than 100");
            }
            else if (number <= 200)
            {
                Console.WriteLine("Between 100 and 200");
            }
            else if (number > 200)
            {
                Console.WriteLine("Greater than 200");
            }
        }
    }
}
