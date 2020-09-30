using System;
using System.IO;
using System.Runtime.Versioning;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../../Resources/02. Line Numbers/Input.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../../Resources/02. Line Numbers/Output.txt"))
                {
                    string line = reader.ReadLine();
                    int index = 1;

                    while (line != null)
                    {
                        writer.WriteLine($"{index}. {line}");
                        index++;

                        line = reader.ReadLine();

                    }
                }
            }

        }
    }
}
