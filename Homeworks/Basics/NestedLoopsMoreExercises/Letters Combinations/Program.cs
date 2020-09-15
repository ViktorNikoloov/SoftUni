using System;

namespace Letters_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ред 1.Малка буква от английската азбука за начало на интервала – от ‘a’ до ‚z’.
            //Ред 2.Малка буква от английската азбука за край на интервала  – от първата буква до ‚z’.
            //Ред 3.Малка буква от английската азбука – от ‘a’ до ‚z’ – като комбинациите съдържащи тази буквата се пропускат.

            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char without = char.Parse(Console.ReadLine());
            int count = 0;

            for (char i = start; i <= end; i++)
            {
                for (char a = start; a <= end; a++)
                {
                    for (char g = start; g <= end; g++)
                    {
                        if (i != without && a != without && g != without)
                        {
                            count++;
                            Console.Write($"{i}{a}{g}");
                            Console.WriteLine();

                        }

                    }

                }

            }

        }
    }
}
