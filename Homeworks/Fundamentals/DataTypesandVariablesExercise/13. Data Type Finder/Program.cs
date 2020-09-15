using System;

namespace _13._Data_Type_Finder
{
    class Program
    {
        private static object dataType;

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Int32 intValue;
            double doubleValue;
            bool boolValue;
            char charValue;

            while (input != "END")
            {
                if (Int32.TryParse(input, out intValue))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (double.TryParse(input, out doubleValue))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (bool.TryParse(input, out boolValue))
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else if (char.TryParse(input, out charValue))
                {
                    Console.WriteLine($"{input} is character type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }

                input = Console.ReadLine();

            }
        }
    }
}
