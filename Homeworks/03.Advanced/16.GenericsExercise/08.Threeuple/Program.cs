using System;
using System.Linq;

namespace _08.Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] nameAndAddress = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string fullName = $"{nameAndAddress[0]} {nameAndAddress[1]}";
            string address = nameAndAddress[2];
            var town = string.Join(" ", nameAndAddress.Skip(3));

            Threeuple<string, string, string> strTuple = new Threeuple<string, string, string>(fullName, address, town);
            Console.WriteLine(strTuple);

            //-------------------------------------------------------------------------------------------------

            string[] nameBeersCountAndCondition = Console.ReadLine().Split();

            string name = nameBeersCountAndCondition[0];
            int litersOfBeer = int.Parse(nameBeersCountAndCondition[1]);
            bool isDrunk = nameBeersCountAndCondition[2] == "drunk" ? true : false;

            Threeuple<string, int, bool> strAndIntTuple = new Threeuple<string, int, bool>(name, litersOfBeer, isDrunk);
            Console.WriteLine(strAndIntTuple);

            //-------------------------------------------------------------------------------------------------


            string[] numbersInput = Console.ReadLine().Split();

            string firstName = numbersInput[0];
            double accountBalance = double.Parse(numbersInput[1]);
            string bankName = numbersInput[2];


            Threeuple<string, double, string> integerAndDoubleTuple = new Threeuple<string, double, string>(firstName, accountBalance, bankName);
            Console.WriteLine(integerAndDoubleTuple);
        }
    }
}
