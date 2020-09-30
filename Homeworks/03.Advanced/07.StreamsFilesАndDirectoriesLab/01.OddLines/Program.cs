using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../../Resources/01. Odd Lines/input.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../../Resources/01. Odd Lines/Output.txt"))
                {
                    string line = reader.ReadLine();
                    int index = 0;

                    while (line != null)
                    {
                        if (index % 2 != 0)
                        {
                            writer.WriteLine(line);
                            writer.WriteLine();

                        }
                        index++;

                        line = reader.ReadLine();
                    }

                }
            }
        }

    }
}
