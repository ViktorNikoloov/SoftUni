using System;
using System.Linq;

namespace _003.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int lastIndex = text.LastIndexOf("\\");

            string[] output = text.Substring(lastIndex + 1).Split(".").ToArray();

            Console.WriteLine("File name:" + " " +output[0]);
            Console.WriteLine($"File extension: {output[1]}");
        }
    }
}
