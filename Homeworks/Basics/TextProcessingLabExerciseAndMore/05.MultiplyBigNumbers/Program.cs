using System;
using System.Linq;
using System.Text;

namespace _05.MultiplyBigNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string input = Console.ReadLine();
            int multiply = int.Parse(Console.ReadLine());

            string output = string.Empty;
            int onMind = 0;

            if (multiply == 0)
            {
                Console.WriteLine("0");
                return;
            }

            while (input[0] == '0')
            {
                input = input.Substring(1);
            }

            StringBuilder sb = new StringBuilder();
            

            for (int i = input.Length -1; i >= 0; i--)
            {
                int result = int.Parse(input[i].ToString()) * multiply + onMind;
                onMind = 0;

                if (result > 9)
                {
                    onMind = result / 10;
                    result = result % 10;
                }

                sb.Append(result);

            }

            if (onMind != 0)
            {
                sb.Append(onMind);
            }

            StringBuilder finaloutput = new StringBuilder();

            for (int i = sb.Length -1; i >= 0; i--)
            {
                finaloutput.Append(sb[i]);
            }
            Console.WriteLine(finaloutput);
            
        }
    }
}
