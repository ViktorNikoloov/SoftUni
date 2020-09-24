using System;

namespace _06._Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                char one = (char)('a' + i);

                for (int g = 0; g < n; g++)
                {
                    char two = (char)('a' + g);

                    for (int j = 0; j < n; j++)
                    {
                        char three = (char)('a' + j);
                        Console.WriteLine($"{one}{two}{three}");
                    }
                }
            }
        }
    }
}
