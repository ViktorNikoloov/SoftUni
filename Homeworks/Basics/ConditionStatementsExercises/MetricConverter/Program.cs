using System;

namespace MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Първи ред: число за преобразуване - реално число
            // Втори ред: входна мерна единица - текст
            // Трети ред: изходна мерна единица(за резултата) - текст
            double number = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string output = Console.ReadLine();

            //3 мерни единици: mm, cm, m

            if (input == "m")
            {
                if (output == "cm")
                {
                    Console.WriteLine($"{number * 100:f3}");
                }

                else if (output == "mm")
                {
                    Console.WriteLine($"{number * 1000:f3}");
                }

                else
                {
                    Console.WriteLine($"{number:f3}");
                }
            }

            else if (input == "cm")
            {
                if (output == "mm")
                {
                    Console.WriteLine($"{number * 10:f3}");
                }

                else if (output == "m")
                {
                    Console.WriteLine($"{number / 100:f3}");
                }
                else
                {
                    Console.WriteLine($"{number:f3}");
                }
            }
            else if (input == "mm")
            {
                if (output == "cm")
                {
                    Console.WriteLine($"{number / 10:f3}");
                }

                else if (output == "m" )
                {
                    Console.WriteLine($"{number / 1000:f3}");
                }
                else
                {
                    Console.WriteLine("{0:F3}", number);
                }
            }    

        }
    }
}
