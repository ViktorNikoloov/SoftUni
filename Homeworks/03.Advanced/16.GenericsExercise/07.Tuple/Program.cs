using System;
using System.Linq;

namespace _07.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nameAndAddress = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string fullName = $"{nameAndAddress[0]} {nameAndAddress[1]}";
            string address = nameAndAddress[2];

            Tuple<string, string> strTuple = new Tuple<string, string>(fullName, address);
            Console.WriteLine(strTuple);

            //-------------------------------------------------------------------------------------------------

            string[] nameAndBeersCount = Console.ReadLine().Split();

            string name = nameAndBeersCount[0];
            int beersCount = int.Parse(nameAndBeersCount[1]);

            Tuple<string, int> strAndIntTuple = new Tuple<string, int>(name, beersCount);
            Console.WriteLine(strAndIntTuple);

            //-------------------------------------------------------------------------------------------------


            double[] numbersInput = Console.ReadLine().Split().Select(double.Parse).ToArray();

            int intNumber = (int)numbersInput[0];
            double doubleNumber = numbersInput[1];

            Tuple<int, double> integerAndDoubleTuple = new Tuple<int, double>(intNumber, doubleNumber);
            Console.WriteLine(integerAndDoubleTuple);
        }
    }
}
