using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randList = new RandomList();

            randList.Add("A");
            randList.Add("B");
            randList.Add("C");
            randList.Add("D");
            Console.WriteLine($"List content: {string.Join(", ", randList)}");

            Console.WriteLine(new string('-', 20));


            Console.WriteLine($"List count: {randList.Count}");
            Console.WriteLine($"Removed string: {randList.RandomString()}");
            Console.WriteLine($"List count: {randList.Count}");

            Console.WriteLine(new string('-', 20));

            Console.WriteLine($"List content: {string.Join(", ", randList)}");

            Console.WriteLine(new string('-', 20));

            Console.WriteLine($"List count: {randList.Count}");
            Console.WriteLine($"Removed string: {randList.RandomString()}");
            Console.WriteLine($"List count: {randList.Count}");

            Console.WriteLine(new string('-', 20));


            Console.WriteLine($"List content: {string.Join(", ", randList)}");

        }
    }
}
